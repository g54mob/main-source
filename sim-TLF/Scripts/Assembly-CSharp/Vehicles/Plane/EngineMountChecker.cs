using System.Collections.Generic;
using AssembleSystem;
using AssembleSystem.FSM.Parts;
using AssembleSystem.FSM.Plane;
using JSAM;
using Loxodon.Framework.Contexts;
using UI.HUD;
using UnityEngine;

namespace Vehicles.Plane
{
	[RequireComponent(typeof(Collider))]
	public class EngineMountChecker : MonoBehaviour
	{
		private AssembleObjectParent _engineParent;

		[SerializeField]
		private int _activeParts;

		[Header("Linked Parts")]
		[SerializeField]
		private PlaneStateMachine _planeStateMachine;

		[SerializeField]
		private List<PartObjectStateMachine> _parts;

		[SerializeField]
		private int _enginePartsCount = 5;

		private InfoCursorsViewModel _infoCursorViewModel;

		private bool _engineInBay;

		private bool _soundPlayed;

		public AssembleObjectParent EngineParent => _engineParent;

		private void Start()
		{
			_infoCursorViewModel = Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (_engineParent == null)
			{
				PartObject component = other.GetComponent<PartObject>();
				if (component == null || component.AssembleParent == null)
				{
					return;
				}
				_engineParent = component.AssembleParent.GetComponent<AssembleObjectParent>();
				if (_engineParent == null)
				{
					return;
				}
			}
			_activeParts++;
			if (!_planeStateMachine.MotorPlaced)
			{
				if (_activeParts >= _enginePartsCount)
				{
					if (!_soundPlayed)
					{
						AudioManager.PlaySound(InteractionLibrarySounds.EngineInPlace);
						_soundPlayed = true;
					}
					_infoCursorViewModel.TickEnabled = true;
				}
				else
				{
					_infoCursorViewModel.TickEnabled = false;
				}
			}
			else
			{
				_infoCursorViewModel.TickEnabled = false;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			_activeParts--;
			if (!_planeStateMachine.MotorPlaced && _activeParts < _enginePartsCount)
			{
				_soundPlayed = false;
				_infoCursorViewModel.TickEnabled = false;
			}
		}

		public bool CanMount()
		{
			if (_activeParts >= _enginePartsCount && _parts.TrueForAll((PartObjectStateMachine x) => !x.Placed))
			{
				return !_engineParent.StateMachine.Placed;
			}
			return false;
		}
	}
}
