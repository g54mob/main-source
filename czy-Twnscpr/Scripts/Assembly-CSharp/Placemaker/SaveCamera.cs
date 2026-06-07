using UnityEngine;

namespace Placemaker
{
	public class SaveCamera : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private Camera cam;

		[SerializeField]
		private Texture2D bigTex;

		public const int saveTexSize = 512;

		private const int jpgQuality = 90;

		public byte[] GetImage(SaveData saveData)
		{
			return null;
		}

		public void Save(SaveData saveData)
		{
		}
	}
}
