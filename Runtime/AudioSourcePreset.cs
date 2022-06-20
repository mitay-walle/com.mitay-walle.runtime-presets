using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class AudioSourceData
{
	[Header("General")]
	public AudioClip clip;
	public AudioMixerGroup outputAudioMixerGroup;
	[Range(0f, 1f)] public float volume;
	[Range(-3f, 3f)] public float pitch;

	public bool loop;
	public bool playOnAwake;
	[Range(0f, 1f)] public float spatialBlend;
	public float minDistance = 2f;
	public float maxDistance = 30f;
	public AnimationCurve Rolloff;
	public AnimationCurve SpreadCurve;
	public AnimationCurve SpatialBlendСurve;
	public AnimationCurve ReverbZoneMixСurve;

	[Header("Other")]
	public AudioRolloffMode rolloffMode = AudioRolloffMode.Custom;
	public float panStereo;
	public float spread = 60f;
	public float dopplerLevel;
	public bool spatializePostEffects;
	public AudioVelocityUpdateMode velocityUpdateMode = AudioVelocityUpdateMode.Dynamic;
	public bool spatialize;
	public float reverbZoneMix;
	public bool bypassEffects;
	public bool bypassListenerEffects;
	public bool bypassReverbZones;
	public int priority = 128;
	public bool mute;

}

[CreateAssetMenu(menuName = "Presets/Audio Source")]
public class AudioSourcePreset : RuntimePreset<AudioSource,AudioSourceData>
{
	public override void ApplyTo(AudioSource target)
	{
		target.clip = data.clip;
		target.volume = data.volume;
		target.pitch = data.pitch;
		target.outputAudioMixerGroup = data.outputAudioMixerGroup;
		target.loop = data.loop;
		target.playOnAwake = data.playOnAwake;
		target.spatialBlend = data.spatialBlend;
		target.rolloffMode = data.rolloffMode;
		target.minDistance = data.minDistance;
		target.maxDistance = data.maxDistance;
		target.panStereo = data.panStereo;
		target.spread = data.spread;
		target.dopplerLevel = data.dopplerLevel;
		target.spatializePostEffects = data.spatializePostEffects;
		target.velocityUpdateMode = data.velocityUpdateMode;
		target.spatialize = data.spatialize;
		target.reverbZoneMix = data.reverbZoneMix;
		target.bypassEffects = data.bypassEffects;
		target.bypassListenerEffects = data.bypassListenerEffects;
		target.bypassReverbZones = data.bypassReverbZones;
		target.priority = data.priority;
		target.mute = data.mute;

		if (data.rolloffMode == AudioRolloffMode.Custom) target.SetCustomCurve(AudioSourceCurveType.CustomRolloff, data.Rolloff);
		target.SetCustomCurve(AudioSourceCurveType.Spread, data.SpreadCurve);
		target.SetCustomCurve(AudioSourceCurveType.SpatialBlend, data.SpatialBlendСurve);
		target.SetCustomCurve(AudioSourceCurveType.ReverbZoneMix, data.ReverbZoneMixСurve);

        #if UNITY_EDITOR
		if (Application.isPlaying) EditorUtility.SetDirty(target);
        #endif
	}
	public override void CopyFrom(AudioSource target)
	{
		data.clip = target.clip;
		data.volume = target.volume;
		data.pitch = target.pitch;
		data.outputAudioMixerGroup = target.outputAudioMixerGroup;
		data.loop = target.loop;
		data.playOnAwake = target.playOnAwake;
		data.spatialBlend = target.spatialBlend;
		data.rolloffMode = target.rolloffMode;
		data.minDistance = target.minDistance;
		data.maxDistance = target.maxDistance;
		data.panStereo = target.panStereo;
		data.spread = target.spread;
		data.dopplerLevel = target.dopplerLevel;
		data.spatializePostEffects = target.spatializePostEffects;
		data.velocityUpdateMode = target.velocityUpdateMode;
		data.spatialize = target.spatialize;
		data.reverbZoneMix = target.reverbZoneMix;
		data.bypassEffects = target.bypassEffects;
		data.bypassListenerEffects = target.bypassListenerEffects;
		data.bypassReverbZones = target.bypassReverbZones;
		data.priority = target.priority;
		data.mute = target.mute;

		data.Rolloff = target.GetCustomCurve(AudioSourceCurveType.CustomRolloff);
		data.SpreadCurve = target.GetCustomCurve(AudioSourceCurveType.Spread);
		data.SpatialBlendСurve = target.GetCustomCurve(AudioSourceCurveType.SpatialBlend);
		data.ReverbZoneMixСurve = target.GetCustomCurve(AudioSourceCurveType.ReverbZoneMix);
		     #if UNITY_EDITOR
		if (Application.isPlaying) EditorUtility.SetDirty(this);
        #endif
	}
}