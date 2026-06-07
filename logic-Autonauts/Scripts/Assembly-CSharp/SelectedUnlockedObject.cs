using UnityEngine;

public class SelectedUnlockedObject : BaseImage
{
	private ObjectType m_ObjectType;

	public void SetObjectType(ObjectType NewType)
	{
		m_ObjectType = NewType;
		Sprite icon = IconManager.Instance.GetIcon(NewType);
		SetSprite(icon);
	}

	public override void SetIndicated(bool Indicated)
	{
		base.SetIndicated(Indicated);
		if (Indicated)
		{
			HudManager.Instance.ActivateHoldableRollover(true, m_ObjectType);
		}
		else
		{
			HudManager.Instance.ActivateHoldableRollover(false, ObjectTypeList.m_Total);
		}
	}
}
