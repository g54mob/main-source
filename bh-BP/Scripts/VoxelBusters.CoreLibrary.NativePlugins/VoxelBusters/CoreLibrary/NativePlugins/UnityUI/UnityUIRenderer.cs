using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins.UnityUI
{
	public class UnityUIRenderer : MonoBehaviour
	{
		[SerializeField]
		private int m_displayOrder;

		public static UnityUIRenderer ActiveRenderer { get; set; }

		public int DisplayOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
	}
}
