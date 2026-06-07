using UnityEngine;

public class HatMod : Hat
{
	public override void Restart()
	{
		base.Restart();
		Vector3 Scale = new Vector3(-1f, 1f, 1f);
		ModManager.Instance.ModHatClass.GetModelScale(m_TypeIdentifier, out Scale);
		m_ModelRoot.transform.localScale = new Vector3(Scale.x, Scale.y, Scale.z);
		Vector3 Rot;
		if (ModManager.Instance.ModHatClass.GetModelRotation(m_TypeIdentifier, out Rot))
		{
			m_ModelRoot.transform.localRotation = Quaternion.Euler(Rot.x, Rot.y, Rot.z);
		}
		Vector3 Trans;
		if (ModManager.Instance.ModHatClass.GetModelTranslation(m_TypeIdentifier, out Trans))
		{
			m_ModelRoot.transform.localPosition = new Vector3(Trans.x, Trans.y, Trans.z);
		}
	}
}
