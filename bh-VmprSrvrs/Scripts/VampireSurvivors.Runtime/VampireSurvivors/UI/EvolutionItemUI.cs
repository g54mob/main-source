using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI
{
	public class EvolutionItemUI : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFormatHighlightSize_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EvolutionItemUI _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFormatHighlightSize_003Ed__20(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private Image _HighlightPanel;

		[SerializeField]
		private GameObject _WeaponPrefab;

		[SerializeField]
		private GameObject _TextPrefab;

		[SerializeField]
		private GameObject _QuestionMarkPrefab;

		[SerializeField]
		private CanvasGroup _CanvasGroup;

		[SerializeField]
		private HorizontalLayoutGroup _layoutGroup;

		private EvolutionData _evoData;

		private PlayerOptions _playerOptions;

		private Dictionary<WeaponType, List<WeaponData>> _weapons;

		private VampireSurvivors.Objects.Characters.CharacterController _character;

		private List<Equipment> _equipment;

		private List<WeaponType> _owned;

		private float _iconPos;

		private float _symbolSpacing;

		private List<GameObject> addedWeaponObjects;

		private bool formatHighlight;

		private const string EqualsString = "=";

		private const string PlusString = "+";

		public void CreateWeaponContainer(PlayerOptions player, Dictionary<WeaponType, List<WeaponData>> weapons, List<WeaponType> owned, EvolutionData evo, VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CFormatHighlightSize_003Ed__20))]
		private IEnumerator FormatHighlightSize()
		{
			return null;
		}

		public void CreateTriassoContainer(PlayerOptions player, Dictionary<WeaponType, List<WeaponData>> weapons, List<WeaponType> owned, EvolutionData evo, VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void CreateGenericContainer(PlayerOptions player, Dictionary<WeaponType, List<WeaponData>> weapons, List<WeaponType> owned, EvolutionData evo, VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private void SetVisibility()
		{
		}

		private void AddCharacterIcon(string character)
		{
		}

		private GameObject AddWeaponIcon(WeaponType t)
		{
			return null;
		}

		private void AddQuestionIcon()
		{
		}

		private bool VisibleItem()
		{
			return false;
		}

		private bool DisabledItem()
		{
			return false;
		}

		private bool UnobtainableItem()
		{
			return false;
		}

		private int GetAvailableWeaponSlots()
		{
			return 0;
		}

		private int GetAvailablePassiveSlots()
		{
			return 0;
		}

		private static bool WeaponsInThisStage(WeaponType t)
		{
			return false;
		}

		private bool OwnsWeapon(WeaponType t)
		{
			return false;
		}

		private List<WeaponType> CreateRequiredWeaponList()
		{
			return null;
		}
	}
}
