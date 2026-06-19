using System.Collections.Generic;
using AssembleSystem;
using Items;
using Loxodon.Framework.Contexts;
using UI.HUD;
using UnityEngine;
using Zenject;

namespace Player
{
	public class PlayerUIToolProgress : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _playerDescriberViewInfo;

		private ToolInfoViewModel _toolInfoViewModel;

		private ToolIconViewModel _toolIconViewModel;

		[Inject]
		private IPlayerEquipService _equipToolService;

		private void Start()
		{
			ApplicationContext applicationContext = Loxodon.Framework.Contexts.Context.GetApplicationContext();
			_toolInfoViewModel = applicationContext.GetService<ToolInfoViewModel>();
			_toolIconViewModel = applicationContext.GetService<ToolIconViewModel>();
		}

		private void Update()
		{
			TrySetToolView();
		}

		private void TrySetToolView()
		{
			if (_playerDescriberViewInfo.Hit.transform != null)
			{
				if (!_playerDescriberViewInfo.Hit.transform.TryGetComponent<IProgressable>(out var component))
				{
					return;
				}
				if (component is PartObject partObject)
				{
					if (partObject.StateMachine != null && !partObject.StateMachine.Placed)
					{
						_toolIconViewModel.Enabled = false;
						return;
					}
					List<PartObject> dependantParts = partObject.GetDependantParts();
					if (dependantParts != null)
					{
						foreach (PartObject item in dependantParts)
						{
							if (item.StateMachine.Placed)
							{
								_toolIconViewModel.Enabled = false;
								return;
							}
						}
					}
				}
				_toolIconViewModel.SetToolType(component.ProgressTool);
				_toolIconViewModel.Enabled = true;
			}
			else
			{
				_toolIconViewModel.Enabled = false;
			}
		}
	}
}
