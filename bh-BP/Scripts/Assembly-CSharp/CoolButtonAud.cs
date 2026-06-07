using FMODUnity;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "CoolButtonAud", menuName = "Btn/CoolButtonAud")]
public class CoolButtonAud : ScriptableObject
{
	[FormerlySerializedAs("SFXOnHover")]
	public EventReference SFXOnNav;

	public EventReference SFXOnPress;

	public virtual void OnBtnNav()
	{
	}

	public virtual void OnBtnPress()
	{
	}
}
