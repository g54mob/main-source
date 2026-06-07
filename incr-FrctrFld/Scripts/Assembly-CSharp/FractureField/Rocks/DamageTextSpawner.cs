using TMPro;
using UnityEngine;

namespace FractureField.Rocks
{
	public class DamageTextSpawner : MonoBehaviour
	{
		private static DamageTextSpawner instance;

		[Header("Prefab")]
		public GameObject pfDamageText;

		[Header("Pool Settings")]
		public int poolSize;

		[Header("Font Settings")]
		public TMP_FontAsset customFont;

		private void Awake()
		{
		}

		public static void SpawnDamageText(float damage, bool isCritical, bool isMegaCritical, Vector3 worldPosition)
		{
		}

		public static GameObject CreateDamageTextPrefab()
		{
			return null;
		}
	}
}
