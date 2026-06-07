using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerMegaloGenevieve : CharacterController
	{
		private List<int2> _tilesToEat;

		private List<int2> _currentTilesBeingEaten;

		private float _eatTimer;

		private float _eatDelay;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private GravityWell _well;

		public WorldEaterVFX _wolrdEater;

		public Action _worldEaterCallback;

		public override bool NeedsCart => false;

		public override void AfterFullInitialization()
		{
		}

		public override void OnQuit()
		{
		}

		public void LastBreath()
		{
		}

		public void TryEatingWorld()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void OnLevelUpSkipped()
		{
		}

		public override void OnLevelUpCompleted()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void CheckTiles()
		{
		}

		private void StartEatingTile(List<int2> posList)
		{
		}

		private void BuildPositionListToBeSpacedApart(List<int2> posList)
		{
		}

		private void EatTile(List<int2> posList)
		{
		}

		private void BlackExplosionAt(List<int2> posList)
		{
		}

		private void CreateBlackEmitter()
		{
		}

		protected override void OnStop()
		{
		}

		protected void ScreenShake()
		{
		}
	}
}
