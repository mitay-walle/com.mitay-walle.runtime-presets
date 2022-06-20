using UnityEngine;

public class RuntimePresetBehaviour : MonoBehaviour
{
	[SerializeField] Object target;
	[SerializeField] RuntimePreset preset;

	[ContextMenu("Apply From Preset")]
	public void Apply()
	{
		if (preset) preset.ApplyTo(target);
	}

	[ContextMenu("Copy To Preset")]
	public void CopyFrom()
	{
		if (preset) preset.CopyFrom(target);
	}
}