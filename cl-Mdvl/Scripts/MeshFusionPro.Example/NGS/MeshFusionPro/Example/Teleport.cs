using UnityEngine;

namespace NGS.MeshFusionPro.Example
{
	public class Teleport : MonoBehaviour
	{
		[SerializeField]
		private string _playerName;

		[SerializeField]
		private Transform _teleportPoint;

		private void OnTriggerEnter(Collider other)
		{
			if (other.transform.name == _playerName)
			{
				other.transform.position = _teleportPoint.position;
				other.transform.rotation = Quaternion.Euler(0f, _teleportPoint.eulerAngles.y, 0f);
			}
		}
	}
}
