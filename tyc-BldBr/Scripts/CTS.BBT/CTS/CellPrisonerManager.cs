using System;
using System.Collections;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class CellPrisonerManager : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Cell _cell;

		[SerializeField]
		private Vector2 _timeBetweenAnimations;

		private List<Func<Agent, IEnumerator>> _idles = new List<Func<Agent, IEnumerator>>();

		private float _ClosingDoorDelay = 1f;

		protected override void OnAwake()
		{
			_idles.Add(PlayPrisonerUpsetAnimation);
			_idles.Add(PlayPrisonerMugAnimation);
			_idles.Add(PlayPrisonerHarmonicaAnimation);
			_idles.Add(PlayPrisonerSadSitDownAnimation);
		}

		protected override void OnDisabled()
		{
			_cell.PrisonerEntered -= OnPrisonerEntered;
			_cell.PrisonerLeaving -= OnPrisonerLeaving;
			StopAllCoroutines();
		}

		protected override void OnEnabled()
		{
			_cell.PrisonerEntered += OnPrisonerEntered;
			_cell.PrisonerLeaving += OnPrisonerLeaving;
		}

		private void OnPrisonerLeaving(Agent prisoner)
		{
			StopAllCoroutines();
		}

		private void OnPrisonerEntered(Agent prisoner)
		{
			StartCoroutine(PrisonerRoutine(prisoner));
		}

		private IEnumerator PrisonerRoutine(Agent prisoner)
		{
			yield return new WaitForSeconds(_ClosingDoorDelay);
			while (true)
			{
				yield return _idles.GetRandom()(prisoner);
				if (prisoner.TryGetComponent<SituationnalBarks_CustomerHuman>(out var component))
				{
					component.Cellule();
				}
				yield return new WaitForSeconds(_timeBetweenAnimations.RandomInRange());
			}
		}

		private IEnumerator PlayPunctualAction(Agent prisoner, AgentAction action)
		{
			if (!(prisoner == null))
			{
				prisoner.ActionPlayer.PlayInstantly(action);
				while (action.Status != AgentAction.EStatus.Completed)
				{
					yield return null;
				}
			}
		}

		private IEnumerator PlayPrisonerUpsetAnimation(Agent prisoner)
		{
			return PlayPunctualAction(prisoner, new PrisonerActionUpset());
		}

		private IEnumerator PlayPrisonerMugAnimation(Agent prisoner)
		{
			return PlayPunctualAction(prisoner, new PrisonerActionMug());
		}

		private IEnumerator PlayPrisonerHarmonicaAnimation(Agent prisoner)
		{
			return PlayPunctualAction(prisoner, new PrisonerActionHarmonica());
		}

		private IEnumerator PlayPrisonerSadSitDownAnimation(Agent prisoner)
		{
			return PlayPunctualAction(prisoner, new PrisonerActionSadSitDown());
		}
	}
}
