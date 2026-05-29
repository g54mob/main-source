using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.Curvy.Generator;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyUnderware.Curvy.Examples
{
	public class E51_InfiniteTrack : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003Csetup_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public E51_InfiniteTrack _003C_003E4__this;

			private int _003Ci_003E5__2;

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
			public _003Csetup_003Ed__22(int _003C_003E1__state)
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

		public CurvySpline TrackSpline;

		public CurvyController Controller;

		public Material RoadMaterial;

		public Text TxtStats;

		[Positive]
		public float CurvationX;

		[Positive]
		public float CurvationY;

		[Positive]
		public float CPStepSize;

		[Positive]
		public int HeadCP;

		[Positive]
		public int TailCP;

		[FluffyUnderware.DevTools.Min(3f, null, null)]
		public int Sections;

		[FluffyUnderware.DevTools.Min(1f, null, null)]
		public int SectionCPCount;

		private int mInitState;

		private bool mUpdateSpline;

		private int mUpdateIn;

		private CurvyGenerator[] mGenerators;

		private int mCurrentGen;

		private float lastSectionEndV;

		private Vector3 mDir;

		private readonly TimeMeasure timeSpline;

		private readonly TimeMeasure timeCG;

		[UsedImplicitly]
		private void Start()
		{
		}

		[UsedImplicitly]
		private void FixedUpdate()
		{
		}

		[IteratorStateMachine(typeof(_003Csetup_003Ed__22))]
		private IEnumerator setup()
		{
			return null;
		}

		private CurvyGenerator buildGenerator()
		{
			return null;
		}

		private void advanceTrack()
		{
		}

		private void advanceSections()
		{
		}

		private void updateStats()
		{
		}

		private void updateSectionGenerator(CurvyGenerator gen, int startCP, int endCP)
		{
		}

		public void Track_OnControlPointReached(CurvySplineMoveEventArgs e)
		{
		}

		private void addTrackCP()
		{
		}
	}
}
