using System;
using Modules.Extensions.EntityFilter;
using ModulesFramework.Data;

namespace ModulesEntitiesFilter
{
    public static class EntityExtension
    {
        public static EntityCheckBuilder With<T>(this Entity entity) where T : struct
        {
            var builder = new EntityCheckBuilder
            {
                entity = entity
            };
            builder.With<T>();
            return builder;
        }
        
        public static EntityCheckBuilder Without<T>(this Entity entity) where T : struct
        {
            var builder = new EntityCheckBuilder
            {
                entity = entity
            };
            builder.Without<T>();
            return builder;
        }
        
        public static EntityCheckBuilder Where<T>(this Entity entity, Func<T, bool> filter) where T : struct
        {
            var builder = new EntityCheckBuilder
            {
                entity = entity
            };
            builder.Where(filter);
            return builder;
        }
    }
}