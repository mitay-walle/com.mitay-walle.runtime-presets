# Runtime Presets
Framework to create & apply presets to UnityEngine.Object at runtime

# Problems
- sharing properties between multiplie Built-in Objects is impossible
- Built-in Presets system is Editor-only
- RectTransform prefab-overrides appear, may brake retweaked layout properties
- Components can't be serialized to JSON

# Solution
- hardcode preset system, with predefined properties, based on:
- - C#-classes for ability to Serialize Objects to one JSON
- - ScriptableObjects for Shared state between Scenes , Prefabs etc

# Summary

