# Unity3d Runtime Presets
Framework to create & apply presets to UnityEngine.Object at runtime

![](https://github.com/mitay-walle/com.mitay-walle.runtime-presets/blob/master/Documentation/AudioSourcePreset_inspector.png)
# Problems
- sharing properties between multiplie Built-in Objects is impossible
- Built-in Presets system ![is Editor-only](https://docs.unity3d.com/Manual/Presets.html)
- ![RectTransform prefab-overrides appearing](https://forum.unity.com/threads/some-properties-of-recttransform-always-appear-in-prefabs-overrides-inspector.601870/), that may brake retweaked layout properties 
- Components can't be serialized to JSON
- no way to easy switch between tuned setups

# Solution
- hardcode preset system, with predefined properties (no Reflection), based on:
- - C#-classes to Serialize multiplie objects to one JSON
- - ScriptableObjects for Shared state between Scenes and Prefabs, and for ability to switch between presets

# Predefined presets included
- RectTransform
- AudioSource
