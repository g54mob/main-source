using Assets.Scripts.Game.Combat.EnemyDebuffs;
using UnityEngine;

namespace Assets.Scripts.Managers;

public class IconManager : MonoBehaviour
{
	public Texture poisonIcon;

	public Texture burnIcon;

	public Texture thornsIcon;

	public Texture echoIcon;

	public Texture bloodmarkIcon;

	public Texture zapIcon;

	public Texture shadowStepIcon;

	public Texture bullseyeIcon;

	public Texture questionMark;

	public Texture[] rankIcons;

	public Texture rankFrameIcon;

	public static IconManager Instance;

	private void Awake()
	{
		if (!(Instance != null))
		{
			Instance = this;
			return;
		}
		GameObject obj = base.gameObject;
		Object.Destroy(obj);
	}

	public Texture GetDebuffIcon(EDebuff debuff)
	{
		return debuff switch
		{
			EDebuff.Echo => echoIcon, 
			EDebuff.Bloodmark => bloodmarkIcon, 
			EDebuff.Poison => poisonIcon, 
			EDebuff.Burn => burnIcon, 
			_ => null, 
		};
	}
}
