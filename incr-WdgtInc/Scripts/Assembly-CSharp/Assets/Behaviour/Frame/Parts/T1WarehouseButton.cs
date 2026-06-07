using Assets.Source.Player;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T1WarehouseButton : MonoBehaviour
	{
		[SerializeField]
		private Transform _highlight;

		[SerializeField]
		private int _tier;

		private T1WarehouseSelector _parent;

		private void Awake()
		{
			_parent = GetComponentInParent<T1WarehouseSelector>();
		}

		private void Start()
		{
			UpdateHighlight();
			if (GamePlayer.Current.TechTier < _tier)
			{
				GetComponentInChildren<FrameButton>().SetActive(active: false);
				SpriteRenderer[] componentsInChildren = GetComponentsInChildren<SpriteRenderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].color = new Color(1f, 1f, 1f, 0.5f);
				}
			}
		}

		public void UpdateHighlight()
		{
			_highlight.gameObject.SetActive(_parent.Frame?.StorageTier == _tier);
		}
	}
}
