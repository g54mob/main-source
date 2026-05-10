using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class TrapSystem : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("Sounds Settings")]
		private MachineSoundsScriptableObject _sfxMachineList;

		[SerializeField]
		[BoxGroup("Animations Settings")]
		private float _fallSpeed;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Animations Settings")]
		private Animator _animator;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Animations Settings")]
		[AnimatorParam("_animator")]
		private string OpenTrap;

		[SerializeField]
		[BoxGroup("Animations Settings")]
		[AnimatorParam("_animator")]
		private string CloseTrap;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("VFX Links")]
		private GameObject _fallingVFX;

		private Cell _selectedCell;

		public float FallSpeed => _fallSpeed;

		private void OnPlaySFXMachine(AudioAsset AudioAsset)
		{
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(AudioAsset);
		}

		public Cell HumanCanBeCaptured(Agent human)
		{
			if (!(human is Customer arg))
			{
				return null;
			}
			if (CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetInteractor(out _selectedCell, Cell.IsAvailableForTrap, arg))
			{
				return _selectedCell;
			}
			return null;
		}

		public Sequence OpenTrapSequence(byte humanSexType, bool bigtrap = false)
		{
			Sequence sequence = DOTween.Sequence();
			sequence.AppendCallback(delegate
			{
				_animator.SetTrigger(OpenTrap);
				if ((bool)_fallingVFX)
				{
					_fallingVFX.SetActive(value: true);
				}
				if (bigtrap)
				{
					OnPlaySFXMachine((humanSexType == 0) ? _sfxMachineList.SoundsList[4] : _sfxMachineList.SoundsList[5]);
				}
				else
				{
					OnPlaySFXMachine((humanSexType == 0) ? _sfxMachineList.SoundsList[2] : _sfxMachineList.SoundsList[3]);
				}
			});
			return sequence;
		}

		public Sequence CloseTrapSequence()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.AppendCallback(delegate
			{
				_animator.SetTrigger(CloseTrap);
				OnPlaySFXMachine(_sfxMachineList.SoundsList[1]);
			});
			return sequence;
		}
	}
}
