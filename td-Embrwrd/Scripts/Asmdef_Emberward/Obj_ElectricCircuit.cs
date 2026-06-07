using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase]
public class Obj_ElectricCircuit : MonoBehaviour
{
	[Serializable]
	public class ElectricCircuitNode
	{
		public Vector3Int position;

		public Obj_TetrisBlock block;
	}

	[CompilerGenerated]
	private sealed class _003CCR_SparkEffect_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<ElectricCircuitNode> list_ConnectedData;

		public List<ElectricCircuitNode> list_OldData;

		public Obj_ElectricCircuit _003C_003E4__this;

		private List<ElectricCircuitNode>.Enumerator _003C_003E7__wrap1;

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
		public _003CCR_SparkEffect_003Ed__19(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private List<Transform> list_DetectNodes;

	[SerializeField]
	private ParticleSystem particle_Spark;

	private List<Vector3Int> list_DetectStartPosition;

	[SerializeField]
	private List<ElectricCircuitNode> list_ConnectedData;

	[SerializeField]
	private List<Obj_AncientMech_Base> list_ConnectedDevice;

	private bool isSoftenElectricBlockEffect;

	private Vector3Int[] directions;

	private Coroutine coroutine_SparkEffect;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGameSettingChanged()
	{
	}

	private void Start()
	{
	}

	private void OnTetrisRecall(Obj_TetrisBlock recallBlock)
	{
	}

	private void OnTetrisRemoveSingleBlock(Obj_TetrisBlock block, Vector3Int pos)
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnTowerRemoved(ABaseTower tower)
	{
	}

	private void UpdateElectricCircuit(bool doPlaySound = true)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SparkEffect_003Ed__19))]
	private IEnumerator CR_SparkEffect(List<ElectricCircuitNode> list_OldData, List<ElectricCircuitNode> list_ConnectedData)
	{
		return null;
	}

	private void UpdateElectricCircuitRecursive(Vector3Int curPos, ref HashSet<Vector3Int> list_DetectedPosition, bool doCheckAllDirections = true)
	{
	}
}
