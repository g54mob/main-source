using UnityEngine;

namespace Placemaker
{
	public class HoverHightlight : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private Mesh mesh;

		private static readonly int hoverPosId;

		private int lastDrawFrame;

		private int lastUpdateFrame;

		public void OnStart()
		{
		}

		public void Draw()
		{
		}

		private void Update()
		{
		}
	}
}
