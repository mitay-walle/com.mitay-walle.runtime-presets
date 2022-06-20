using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class RectTransformData
{
	public Vector2 sizeDelta = Vector2.one * 100f;
	public Vector2 pivot = Vector2.one * .5f;
	public Vector3 anchoredPosition3D = Vector3.zero;
	public Vector2 anchorMin = Vector2.one * .5f;
	public Vector2 anchorMax = Vector2.one * .5f;
	public Vector3 localPosition = Vector3.zero;
	public Quaternion localRotation = Quaternion.identity;
	public Vector3 localScale = Vector3.one;
}

[CreateAssetMenu(menuName = "Presets/Rect Transform")]
public class RectTransformPreset : RuntimePreset<RectTransform,RectTransformData>
{
	public override void ApplyTo(RectTransform target)
	{
		target.localPosition = data.localPosition;
		target.localRotation = data.localRotation;
		target.localScale = data.localScale;
		target.anchoredPosition3D = data.anchoredPosition3D;
		target.anchorMin = data.anchorMin;
		target.anchorMax = data.anchorMax;
		target.sizeDelta = data.sizeDelta;
		target.pivot = data.pivot;
#if UNITY_EDITOR
		if (!Application.isPlaying) EditorUtility.SetDirty(target);
#endif
	}
	public override void CopyFrom(RectTransform target)
	{
		data.sizeDelta = target.sizeDelta;
		data.pivot = target.pivot;
		data.anchoredPosition3D = target.anchoredPosition3D;
		data.anchorMin = target.anchorMin;
		data.anchorMax = target.anchorMax;
		data.localPosition = target.localPosition;
		data.localRotation = target.localRotation;
		data.localScale = target.localScale;
#if UNITY_EDITOR
		if (Application.isPlaying) EditorUtility.SetDirty(this);
#endif
	}
}