using System;
using ModulesFramework.Data;

namespace Modules.Extensions.EntityFilter
{
    public struct EntityCheckBuilder
    {
        public Entity entity;
        private bool _isFailed;

        public EntityCheckBuilder With<T>() where T : struct
        {
            if (_isFailed)
                return this;

            if (!entity.IsAlive())
            {
                _isFailed = true;
                return this;
            }

            _isFailed = _isFailed || !entity.HasComponent<T>();
            return this;
        }

        public EntityCheckBuilder Without<T>() where T : struct
        {
            if (_isFailed)
                return this;

            if (!entity.IsAlive())
            {
                _isFailed = false;
                return this;
            }

            _isFailed = _isFailed || entity.HasComponent<T>();
            return this;
        }

        public EntityCheckBuilder Where<T>(Func<T, bool> filter) where T : struct
        {
            if (_isFailed)
                return this;

            if (!entity.IsAlive())
            {
                _isFailed = true;
                return this;
            }

            if (!entity.HasComponent<T>())
            {
                _isFailed = true;
                return this;
            }

            _isFailed = _isFailed || !filter(entity.GetComponent<T>());
            return this;
        }

        public static implicit operator bool(EntityCheckBuilder builder) => !builder._isFailed;
    }
}