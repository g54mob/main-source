using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.TechTree
{
	public class UpgradeNodeConnection : SerializedMonoBehaviour
	{
		public LineRenderer Line;

		private Transform _start;

		private Transform _end;

		public void Init(Transform start, Transform end)
		{
			_start = start;
			_end = end;
		}

		public void SetLineColor(Color color)
		{
			Line.startColor = color;
			Line.endColor = color;
		}

		public void Update()
		{
			Vector3 position = _start.position;
			position.z = -2f;
			Vector3 position2 = _end.position;
			position2.z = -2f;
			Line.SetPosition(0, position);
			Line.SetPosition(1, position2);
		}
	}
}
