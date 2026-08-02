using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[CreateAssetMenu(menuName = "HQ FPS Template/Equipment Component/Model", fileName = "Equipment Model Info")]
	public class EquipmentModelInfo : ScriptableObject
	{
		public string FovProperty = "_FOV";

		[Range(10f, 120f)]
		public float TargetFOV = 45f;

		[Space]
		[DatabaseProperty]
		public string SkinIDProperty = "Skin ID";

		[Reorderable]
		public FPItemSkinsList Skins = new FPItemSkinsList();

		public bool HasSkins
		{
			get
			{
				if (Skins != null)
				{
					return Skins.Count > 0;
				}
				return false;
			}
		}
	}
}
