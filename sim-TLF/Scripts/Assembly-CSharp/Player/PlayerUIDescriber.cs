using Extensions;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using UI.Descriptor;
using UI.HUD;
using UI.Inventory;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace Player
{
	public class PlayerUIDescriber : MonoBehaviour, IDescriberRayMask
	{
		[SerializeField]
		private RaycasterInfo _playerDescriberViewInfo;

		private DescriptorViewModel _descriptorVM;

		private InfoCursorsViewModel _infoCursorsVM;

		[Inject]
		private PlayerHUDView _hudView;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		private void Start()
		{
			_infoCursorsVM = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
			_descriptorVM = new DescriptorViewModel();
			_hudView.DescriptorView.SetDataContext(_descriptorVM);
		}

		private void OnEnable()
		{
			RenderPipelineManager.beginCameraRendering += CastDescriberRay;
		}

		private void OnDisable()
		{
			RenderPipelineManager.beginCameraRendering -= CastDescriberRay;
		}

		private void CastDescriberRay(ScriptableRenderContext context, Camera camera)
		{
			if (camera.CompareTag("MainCamera"))
			{
				_playerDescriberViewInfo.ShootRay(camera);
			}
		}

		private void Update()
		{
			TrySetDescriber();
		}

		public void RestrictToLayers(LayerMask mask)
		{
			_playerDescriberViewInfo.OverrideLayerMask(mask);
		}

		public void ClearRestriction()
		{
			_playerDescriberViewInfo.ClearLayerMaskOverride();
		}

		private void TrySetDescriber()
		{
			if (_infoCursorsVM != null)
			{
				if (_playerDescriberViewInfo.Hit.transform != null)
				{
					_descriptorVM.DescriptorText = _playerDescriberViewInfo.Hit.transform.gameObject.name;
					_infoCursorsVM.ItemName = _playerDescriberViewInfo.Hit.transform.gameObject.name.ToCleanName();
				}
				else
				{
					_infoCursorsVM.ItemName = string.Empty;
					_descriptorVM.DescriptorText = string.Empty;
				}
			}
		}
	}
}
