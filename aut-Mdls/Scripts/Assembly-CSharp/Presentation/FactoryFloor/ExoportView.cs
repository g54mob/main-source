#define ENABLE_DEBUG_EXCEPTIONS
#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor
{
	public class ExoportView : FactoryResourceHolderView<ExoportBehaviour>
	{
		[SerializeField]
		private SpriteRenderer[] _spriteRenderer = new SpriteRenderer[0];

		private readonly SortedList<string, Sprite> _sortedSprites = new SortedList<string, Sprite>();

		protected override void Init()
		{
			base.Init();
			_behaviour.OnNewResourceAdded.RegisterMainThread(OnNewResourceAdded);
			_behaviour.OnNewShapeResourceAdded.RegisterMainThread(OnNewShapeResourceAdded);
			_behaviour.OnResourcesCleared.RegisterMainThread(OnResourcesCleared);
			OnResourcesCleared();
			_behaviour.GetAllUniqueResourcesAdded(OnNewResourceAdded, OnNewShapeResourceAdded);
		}

		protected override void OnDestroy()
		{
			if (_behaviour != null)
			{
				_behaviour.OnNewResourceAdded.UnRegisterMainThread(OnNewResourceAdded);
				_behaviour.OnNewShapeResourceAdded.UnRegisterMainThread(OnNewShapeResourceAdded);
				_behaviour.OnResourcesCleared.UnRegisterMainThread(OnResourcesCleared);
			}
			base.OnDestroy();
		}

		private void OnResourcesCleared()
		{
			SpriteRenderer[] spriteRenderer = _spriteRenderer;
			for (int i = 0; i < spriteRenderer.Length; i++)
			{
				spriteRenderer[i].enabled = false;
			}
			_sortedSprites.Clear();
		}

		private void OnNewResourceAdded(ResourceDataSO resource)
		{
			if (_sortedSprites.Count < _spriteRenderer.Length)
			{
				if (!(resource is NonShapeResourceDataSO nonShapeResourceDataSO))
				{
					this.LogError($"{resource.ID} is not supported", "OnNewResourceAdded", 58);
				}
				else
				{
					AddSprite(resource.ID.ToString(), nonShapeResourceDataSO.Sprite);
				}
			}
		}

		private void OnNewShapeResourceAdded(ShapeData shapeData)
		{
			if (_sortedSprites.Count < _spriteRenderer.Length)
			{
				if (shapeData.GridIcon == null)
				{
					this.DevException(string.Format("The resource data included does not a have {0}.\nHash: {1}", "GridIcon", shapeData.GetShapeHash()), "OnNewShapeResourceAdded", 72);
					return;
				}
				Sprite sprite = Sprite.Create(shapeData.GridIcon, new Rect(0f, 0f, shapeData.GridIcon.width, shapeData.GridIcon.height), new Vector2(0.5f, 0.5f));
				AddSprite(shapeData.GetShapeHash().ToString(), sprite);
			}
		}

		public override void ReceiveResourceView(ResourceView resource, int inputIndex, bool scaleUpResource = true)
		{
			_audioManagerLocator.AudioManager.PlayItemDeliveredDepot(base.transform.position);
			base.ReceiveResourceView(resource, inputIndex, scaleUpResource);
		}

		private void AddSprite(string key, Sprite sprite)
		{
			_spriteRenderer[_sortedSprites.Count].enabled = true;
			_sortedSprites.Add(key, sprite);
			FillSpriteRenderers();
		}

		private void FillSpriteRenderers()
		{
			for (int i = 0; i < _sortedSprites.Values.Count; i++)
			{
				Sprite sprite = _sortedSprites.Values[i];
				_spriteRenderer[i].sprite = sprite;
			}
		}
	}
}
