using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors
{
	public class DeathFightDirecter : PhaserSprite
	{
		[CompilerGenerated]
		private sealed class _003C_BlockCutscene_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DeathFightDirecter _003C_003E4__this;

			private float _003CstruggleTimer_003E5__2;

			private float2 _003CprojectileStartPos_003E5__3;

			private float _003CstruggleRange_003E5__4;

			private float2 _003CtargetPos_003E5__5;

			private float2 _003CtoBlockTarget_003E5__6;

			private Vector3 _003CscytheRotation_003E5__7;

			private float _003CsoundTimer_003E5__8;

			private List<Transform> _003CoriginalCameraTargets_003E5__9;

			private Camera _003CmainCamera_003E5__10;

			private float _003CorthographicSize_003E5__11;

			private float2 _003CstartBodyPos_003E5__12;

			private float2 _003CbodyTargetPos_003E5__13;

			private float2 _003CleftHandOffset_003E5__14;

			private GameObject _003CcameraTarget_003E5__15;

			private PhaserSprite _003CfullscreenGlitch_003E5__16;

			private float _003CfadeTimer_003E5__17;

			private List<PhaserSprite> _003Cmasks_003E5__18;

			private Color _003CstartColor_003E5__19;

			private Vector3 _003CtilesetStartPos_003E5__20;

			private List<PhaserSprite> _003Ceyes_003E5__21;

			private float _003CexplosionTimer_003E5__22;

			private int _003Ci_003E5__23;

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
			public _003C_BlockCutscene_003Ed__40(int _003C_003E1__state)
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

		private float _Radius1;

		private float _Radius2;

		private float _Radius3;

		private float _Radius4;

		private float _Radius5;

		private float _Radius6;

		private float _Radius7;

		private float _myAngle1;

		private float _myAngle2;

		private float _myAngle3;

		private float _myAngle4;

		private float _myAngle5;

		private float _myAngle6;

		private float _myAngle7;

		private PhaserSprite _eye1;

		private PhaserSprite _eye2;

		private PhaserSprite _eye3;

		private PhaserSprite _eye4;

		private PhaserSprite _eye5;

		private PhaserSprite _eye6;

		private PhaserSprite _eye7;

		private TileSprite _stars1;

		private TileSprite _stars2;

		private PhaserSprite _LeftHand;

		private PhaserSprite _RightHand;

		private float _angleUnit;

		private SpriteMask _spriteMask;

		private List<MultiTargetTween> _allTweens;

		public Transform _protectionTarget;

		public Transform _projectileToBlock;

		public Enemy_TP_Death _death;

		protected override void Awake()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void UpdateDirecterSubObjects()
		{
		}

		private void UpdateDepths()
		{
		}

		private void UpdateMaskPositions()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void StartBlockCutscene()
		{
		}

		private float BlockDistance()
		{
			return 0f;
		}

		private float2 BlockPosition()
		{
			return default(float2);
		}

		[IteratorStateMachine(typeof(_003C_BlockCutscene_003Ed__40))]
		private IEnumerator _BlockCutscene()
		{
			return null;
		}

		private void BreakSomething(PhaserSprite thing)
		{
		}

		private void BreakMask(PhaserSprite mask)
		{
		}
	}
}
