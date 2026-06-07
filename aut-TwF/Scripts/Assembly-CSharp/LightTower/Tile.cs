using UnityEngine;

namespace LightTower
{
	public class Tile : MonoBehaviour
	{
		public enum ETileType
		{
			Default = 0,
			Path = 1,
			Border = 2,
			Water = 3,
			Mountain = 4
		}

		[SerializeField]
		private ETileType tileType;

		[SerializeField]
		private bool preventBuildOnMapGeneration;

		[SerializeField]
		private GameObject[] environmentProps;

		public ETileType TileType
		{
			get
			{
				return tileType;
			}
			protected set
			{
				tileType = value;
			}
		}

		public bool PreventBuildOnMapGeneration => preventBuildOnMapGeneration;

		private void EnableEnvironmentProps()
		{
			GameObject[] array = environmentProps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
		}

		private void DisableEnvironmentProps()
		{
			GameObject[] array = environmentProps;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
		}

		protected virtual void Awake()
		{
			base.gameObject.layer = LayerMask.NameToLayer("Ground");
		}

		protected virtual void Start()
		{
		}

		public bool CanBuildOn()
		{
			return tileType switch
			{
				ETileType.Default => true, 
				ETileType.Path => false, 
				ETileType.Border => false, 
				ETileType.Water => false, 
				ETileType.Mountain => false, 
				_ => true, 
			};
		}

		public void ShowEnvironmentProps(bool show)
		{
			if (environmentProps == null)
			{
				return;
			}
			for (int i = 0; i < environmentProps.Length; i++)
			{
				if (!(environmentProps[i] == null))
				{
					environmentProps[i].SetActive(show);
				}
			}
		}
	}
}
