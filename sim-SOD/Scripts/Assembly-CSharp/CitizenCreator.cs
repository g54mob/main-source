using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CitizenCreator : Creator
{
	[CompilerGenerated]
	private sealed class _003CPopulate_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CitizenCreator _003C_003E4__this;

		private string _003Cseed_003E5__2;

		private int _003CcitCursor_003E5__3;

		private int _003CemployedCitizens_003E5__4;

		private int _003CunemployedCitizens_003E5__5;

		private int _003CcitizensOrCouplesToSpawn_003E5__6;

		private List<ResidenceController> _003CallVacantResidences_003E5__7;

		private int _003CapartmentCapacity_003E5__8;

		private int _003ChomelessToSpawn_003E5__9;

		private int _003CtotalHomelessToSpawn_003E5__10;

		private List<Citizen> _003CwithoutJobs_003E5__11;

		private List<Occupation> _003CfreeJobs_003E5__12;

		private List<CompanyPreset> _003CselfEmployedAutoCreate_003E5__13;

		private List<ResidenceController> _003CallInhabitedResidences_003E5__14;

		private List<Citizen> _003CcitizensToHouse_003E5__15;

		private int _003CsetupPhaseCursor_003E5__16;

		private int _003CpopulatePhase_003E5__17;

		private float _003CspawnProgress_003E5__18;

		private float _003CjobProgress_003E5__19;

		private float _003ChousingProgress_003E5__20;

		private float _003ChomelessProgress_003E5__21;

		private float _003CmiscProgress_003E5__22;

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
		public _003CPopulate_003Ed__17(int _003C_003E1__state)
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

	public int loadChunk;

	public GameObject unemploymentHolder;

	public GameObject criminalHolder;

	public OccupationPreset unemployedPreset;

	public OccupationPreset retiredPreset;

	public GameObject citizenObj;

	public Texture agentTexture;

	public Texture suspectTexture;

	public GameObject citizenHolder;

	public int rUnemployed;

	public int rRetired;

	private static CitizenCreator _instance;

	public static CitizenCreator Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public override void StartLoading()
	{
	}

	[IteratorStateMachine(typeof(_003CPopulate_003Ed__17))]
	private IEnumerator Populate()
	{
		return null;
	}

	public Occupation CreateUnemployed()
	{
		return null;
	}

	public Occupation CreateCriminal(OccupationPreset preset)
	{
		return null;
	}
}
