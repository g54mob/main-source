using System;
using System.Collections.Generic;
using DG.Tweening;
using SuperTiled2Unity;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.UI
{
	public class TreasureReelUI : MonoBehaviour
	{
		[SerializeField]
		private string _ColorString;

		[SerializeField]
		private float _Alpha;

		private float Speed;

		[SerializeField]
		private Animator Anim;

		[SerializeField]
		private Image RewardBeam;

		[SerializeField]
		private GameObject Reward;

		[SerializeField]
		private Image RewardIcon;

		[SerializeField]
		private Image _FlashBackground;

		[SerializeField]
		private RectTransform _Star1;

		[SerializeField]
		private RectTransform _Star2;

		[SerializeField]
		private GameObject _ReelIcon;

		[SerializeField]
		[ReadOnly]
		private Texture2D _GeneratedTexture;

		[SerializeField]
		private RawImage _RewardImage;

		private int _minAmountOfPowerups;

		private float _originalWidth;

		private Vector3 _originalPosition;

		private RectTransform _rectTrans;

		private List<Tuple<string, string>> _weaponNamesNew;

		private bool _isActive;

		private static readonly int Reveal1;

		private LevelUpFactory _levelUp;

		private PlayerOptions _playerOptions;

		private Tween _Star1TweenRot;

		private Tween _Star1TweenScale;

		private Tween _Star2TweenRot;

		private Tween _Star2TweenScale;

		private Dictionary<WeaponType, List<WeaponData>> _weapons;

		[Inject]
		private void Constructor(LevelUpFactory level, PlayerOptions playerOptions)
		{
		}

		private void Start()
		{
		}

		public void SetRewardIcon(string spriteName, string textureName)
		{
		}

		public void GenerateWeapons(GameSessionData session, Dictionary<WeaponType, List<WeaponData>> weapons, PrizeType prize, VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private void MakeTexture_Any(bool shuffle = true)
		{
		}

		private void MakeTexture_PowerUps(bool shuffle = true)
		{
		}

		private void MakeTexture_ExistingWeapons(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void SetWeapons(List<Tuple<string, string>> weapons)
		{
		}

		public void StartScrolling()
		{
		}

		public void StopScrolling()
		{
		}

		private void Update()
		{
		}

		public void Reveal()
		{
		}

		public void HideBeam()
		{
		}

		public void Finish()
		{
		}

		public void Reset()
		{
		}

		public void FlashOn()
		{
		}

		public void FlashOff()
		{
		}

		private void DoStarTweens()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
