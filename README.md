# Entity Filter for Modules Framework

**Note**: this is the extension for [Modules Framework](https://github.com/JackLite/ModulesFramework) (MF).

Usage:
```csharp
public void SomeMethod(Entity entity) {
    // check if entity contains component
    entity.With<SomeComponent>();
    
    // check if there is no component on entity
    // returns true also if entity is destroyed
    entity.Without<SomeComponent>();
    
    // check custom filter
    // check if entity has component so you don't need it
    entity.Where<SomeComponent>(comp => comp.isEnemy);
    
    // you may combine filter like in Query
    entity.With<SomeComponent>()
        .Without<OtherComponent>()
        .Where<ThridComponent>(c => c.x > 10);
}
```