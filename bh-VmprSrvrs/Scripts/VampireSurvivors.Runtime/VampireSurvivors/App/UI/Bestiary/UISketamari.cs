using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.UI.Bestiary
{
	public class UISketamari : MonoBehaviour
	{
		[SerializeField]
		private float _Speed;

		[SerializeField]
		private GameObject _BonesParent;

		private DataManager _dataManager;

		private readonly EnemyType[] _enemiesArray;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		public void Generate(DataManager dataManager)
		{
		}

		private void AddBones(GameObject container, int amount, float radiusMin, float radiusMax, float scaleMax, bool flipY)
		{
		}
	}
}
