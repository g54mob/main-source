using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class GospelManager : MonoBehaviour
	{
		[SerializeField]
		private Image _Clap;

		[SerializeField]
		private UISpriteAnimation _ClapInAnim;

		[SerializeField]
		private UISpriteAnimation _ClapOutAnim;

		[SerializeField]
		private ParticleEmitterManager _ParticleEmitter;

		[SerializeField]
		[CanBeNull]
		private Image _Panel;

		private int _claps;

		private int _maxClaps;

		private Action _callback;

		private List<ParticleSystem> _particles;

		private GravityWell _gravityWell;

		private PlayerOptions _playerOptions;

		private List<string> _frames;

		[Inject]
		private void Construct(PlayerOptions player)
		{
		}

		public void PlayEffect(Action cb = null)
		{
		}

		private void Clap()
		{
		}

		private void BuildFireworks()
		{
		}

		private void SetRandomPosition(ParticleSystem ps)
		{
		}

		private void PlayFirework(int i)
		{
		}
	}
}
