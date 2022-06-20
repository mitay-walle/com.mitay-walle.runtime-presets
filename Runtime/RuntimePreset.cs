using UnityEngine;

public abstract class RuntimePreset : ScriptableObject
{
	public abstract bool CanBeAppliedTo(Object target);
	public abstract void ApplyTo(Object target);
	public abstract void CopyFrom(Object target);
}
public abstract class RuntimePreset<TObject, TData> : RuntimePreset
	where TObject : Object
	where TData : new()
{
	public TData data = new TData();
	public override bool CanBeAppliedTo(Object target) => target != null && target is TObject;

	public override void ApplyTo(Object target)
	{
		if (CanBeAppliedTo(target))
		{
			ApplyTo(target as TObject);
		}
	}
	public override void CopyFrom(Object target)
	{
		if (CanBeAppliedTo(target))
		{
			CopyFrom(target as TObject);
		}
	}

	public abstract void ApplyTo(TObject target);
	public abstract void CopyFrom(TObject target);
}