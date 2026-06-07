using System.Collections.Generic;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using Presentation.FactoryFloor.FactoryObjectViews.Buildings;
using Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.FreightHub;
using Presentation.Shapes.ShapeRenderer;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class FreightHubView : FactoryResourceHolderView<FreightHubBehaviour>
	{
		[SerializeField]
		private SpriteRenderer[] _inSlotSpriteRenderers = new SpriteRenderer[4];

		[SerializeField]
		private SpriteRenderer[] _outSlotSpriteRenderers = new SpriteRenderer[4];

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private AnimationFinishedHandler _animationFinishedHandler;

		[SerializeField]
		private Transform _freighterDockTransform;

		[SerializeField]
		private Sprite _defaultSlotSprite;

		[SerializeField]
		private List<FreightCrateView> _inCrateViews = new List<FreightCrateView>();

		[SerializeField]
		private List<FreightCrateView> _outCrateViews = new List<FreightCrateView>();

		private Material _defaultSlotMaterial;

		private readonly Resource[] _currentInSlotResources = new Resource[4];

		private readonly Resource[] _currentOutSlotResources = new Resource[4];

		private Dictionary<FreightHubBehaviour.FreightHubSlot, ShapeData> _renderingShapeDatas = new Dictionary<FreightHubBehaviour.FreightHubSlot, ShapeData>();

		private static readonly int[] CrateInAnimatorHashes = new int[4]
		{
			Animator.StringToHash("CrateIn1"),
			Animator.StringToHash("CrateIn2"),
			Animator.StringToHash("CrateIn3"),
			Animator.StringToHash("CrateIn4")
		};

		private static readonly int[] CrateOutAnimatorHashes = new int[4]
		{
			Animator.StringToHash("CrateOut1"),
			Animator.StringToHash("CrateOut2"),
			Animator.StringToHash("CrateOut3"),
			Animator.StringToHash("CrateOut4")
		};

		private static readonly int[] CrateInOutAnimatorHashes = new int[4]
		{
			Animator.StringToHash("CrateInOut1"),
			Animator.StringToHash("CrateInOut2"),
			Animator.StringToHash("CrateInOut3"),
			Animator.StringToHash("CrateInOut4")
		};

		private static readonly int[] CrateOutInAnimatorHashes = new int[4]
		{
			Animator.StringToHash("CrateOutIn1"),
			Animator.StringToHash("CrateOutIn2"),
			Animator.StringToHash("CrateOutIn3"),
			Animator.StringToHash("CrateOutIn4")
		};

		protected override void Awake()
		{
			base.Awake();
			_defaultSlotMaterial = _inSlotSpriteRenderers[0].material;
		}

		protected override void OnDestroy()
		{
			ResetView();
			base.OnDestroy();
		}

		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
			_behaviour.OnInSlotChanged.RegisterMainThread(OnInSlotChanged);
			_behaviour.OnOutSlotChanged.RegisterMainThread(OnOutSlotChanged);
			_behaviour.OnLoadCrateIntoFreighter.RegisterMainThread(OnLoadCrateIntoFreighter);
			_behaviour.OnUnloadCrateFromFreighter.RegisterMainThread(OnUnloadCrateFromFreighter);
			for (int i = 0; i < _inSlotSpriteRenderers.Length; i++)
			{
				FreightHubBehaviour.FreightHubSlot inSlot = _behaviour.GetInSlot(i);
				UpdateSlotResourceSprite(_inSlotSpriteRenderers[i], inSlot);
				_currentInSlotResources[i] = inSlot.Resource;
				inSlot = _behaviour.GetOutSlot(i);
				UpdateSlotResourceSprite(_outSlotSpriteRenderers[i], inSlot);
				_currentOutSlotResources[i] = inSlot.Resource;
			}
		}

		protected override void ResetFactoryObject()
		{
			ResetView();
			for (int i = 0; i < _inSlotSpriteRenderers.Length; i++)
			{
				_inSlotSpriteRenderers[i].material = _defaultSlotMaterial;
				_inSlotSpriteRenderers[i].sprite = _defaultSlotSprite;
				_outSlotSpriteRenderers[i].material = _defaultSlotMaterial;
				_outSlotSpriteRenderers[i].sprite = _defaultSlotSprite;
			}
			base.ResetFactoryObject();
		}

		private void ResetView()
		{
			StopRenderingAllShapes();
			if (_behaviour != null)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
				_behaviour.OnInSlotChanged.UnRegisterMainThread(OnInSlotChanged);
				_behaviour.OnOutSlotChanged.UnRegisterMainThread(OnOutSlotChanged);
				_behaviour.OnLoadCrateIntoFreighter.UnRegisterMainThread(OnLoadCrateIntoFreighter);
				_behaviour.OnUnloadCrateFromFreighter.UnRegisterMainThread(OnUnloadCrateFromFreighter);
			}
		}

		private void OnInSlotChanged(int index, FreightHubBehaviour.FreightHubSlot slot)
		{
			if (_currentInSlotResources[index] != slot.Resource)
			{
				_currentInSlotResources[index] = slot.Resource;
				UpdateSlotResourceSprite(_inSlotSpriteRenderers[index], slot);
			}
		}

		private void OnOutSlotChanged(int index, FreightHubBehaviour.FreightHubSlot slot)
		{
			if (_currentOutSlotResources[index] != slot.Resource)
			{
				_currentOutSlotResources[index] = slot.Resource;
				UpdateSlotResourceSprite(_outSlotSpriteRenderers[index], slot);
			}
		}

		private void OnLoadCrateIntoFreighter(int index, FreightHubBehaviour.FreightHubSlot freightHubSlot, bool alreadyHasResource)
		{
			_outCrateViews[index].SetResource(freightHubSlot.Resource);
			if (alreadyHasResource)
			{
				_animator.SetTrigger(CrateOutInAnimatorHashes[index]);
			}
			else
			{
				_animator.SetTrigger(CrateOutAnimatorHashes[index]);
			}
		}

		private void OnUnloadCrateFromFreighter(int index, FreightHubBehaviour.FreightHubSlot freightHubSlot, bool hasLeftOversAfter)
		{
			if (!hasLeftOversAfter)
			{
				_animator.SetTrigger(CrateInAnimatorHashes[index]);
			}
			else
			{
				_animator.SetTrigger(CrateInOutAnimatorHashes[index]);
			}
			if (_behaviour.GetOutSlot(index).HasResource)
			{
				_inCrateViews[index].SetResource(_behaviour.GetOutSlot(index).Resource);
			}
		}

		private void UpdateSlotResourceSprite(SpriteRenderer spriteRenderer, FreightHubBehaviour.FreightHubSlot slot)
		{
			StopRenderingShape(slot);
			if (slot.HasResource)
			{
				if (slot.Resource.Data is NonShapeResourceDataSO nonShapeResourceDataSO)
				{
					spriteRenderer.sprite = nonShapeResourceDataSO.Sprite;
					spriteRenderer.material = _defaultSlotMaterial;
					return;
				}
				if (slot.Resource is ShapeResource shapeResource)
				{
					Texture2D gridIcon = shapeResource.ShapeData.GridIcon;
					if (gridIcon != null)
					{
						spriteRenderer.sprite = Sprite.Create(gridIcon, new Rect(0f, 0f, gridIcon.width, gridIcon.height), new Vector2(0.5f, 0.5f));
						spriteRenderer.material = _defaultSlotMaterial;
					}
					else
					{
						spriteRenderer.sprite = _defaultSlotSprite;
						spriteRenderer.material = ShapeRendererManager.RenderShape(shapeResource.ShapeData, continuous: false, updateCameraRotation: false, this);
						_renderingShapeDatas.Add(slot, shapeResource.ShapeData);
					}
					return;
				}
			}
			spriteRenderer.sprite = null;
			spriteRenderer.material = _defaultSlotMaterial;
		}

		private void StopRenderingShape(FreightHubBehaviour.FreightHubSlot slot)
		{
			if (_renderingShapeDatas.TryGetValue(slot, out var value))
			{
				ShapeRendererManager.StopRenderShape(value, this);
				_renderingShapeDatas.Remove(slot);
			}
		}

		private void StopRenderingAllShapes()
		{
			foreach (KeyValuePair<FreightHubBehaviour.FreightHubSlot, ShapeData> renderingShapeData in _renderingShapeDatas)
			{
				ShapeRendererManager.StopRenderShape(renderingShapeData.Value, this);
			}
			_renderingShapeDatas.Clear();
		}
	}
}
