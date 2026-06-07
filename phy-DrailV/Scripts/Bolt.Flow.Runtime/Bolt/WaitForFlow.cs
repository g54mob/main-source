using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ludiq;
using UnityEngine;

namespace Bolt
{
	[UnitCategory("Time")]
	[UnitOrder(6)]
	[TypeIcon(typeof(WaitUnit))]
	public sealed class WaitForFlow : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		public sealed class Data : IGraphElementData
		{
			public bool[] inputsActivated;

			public bool isWaitingCoroutine;
		}

		[SerializeAs("inputCount")]
		private int _inputCount = 2;

		[Serialize]
		[Inspectable]
		public bool resetOnExit { get; set; }

		[DoNotSerialize]
		[Inspectable]
		[UnitHeaderInspectable("Inputs")]
		public int inputCount
		{
			get
			{
				return _inputCount;
			}
			set
			{
				_inputCount = Mathf.Clamp(value, 2, 10);
			}
		}

		[DoNotSerialize]
		public ReadOnlyCollection<ControlInput> awaitedInputs { get; private set; }

		[DoNotSerialize]
		public ControlInput reset { get; private set; }

		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		protected override void Definition()
		{
			List<ControlInput> list = new List<ControlInput>();
			awaitedInputs = list.AsReadOnly();
			exit = ControlOutput("exit");
			for (int i = 0; i < inputCount; i++)
			{
				int _i = i;
				ControlInput controlInput = ControlInputCoroutine(_i.ToString(), (Flow flow) => Enter(flow, _i), (Flow flow) => EnterCoroutine(flow, _i));
				list.Add(controlInput);
				Succession(controlInput, exit);
			}
			reset = ControlInput("reset", Reset);
		}

		public IGraphElementData CreateData()
		{
			Data data = new Data();
			data.inputsActivated = new bool[inputCount];
			return data;
		}

		private ControlOutput Enter(Flow flow, int index)
		{
			Data elementData = flow.stack.GetElementData<Data>(this);
			elementData.inputsActivated[index] = true;
			if (CheckActivated(flow))
			{
				if (resetOnExit)
				{
					Reset(flow);
				}
				return exit;
			}
			return null;
		}

		private bool CheckActivated(Flow flow)
		{
			Data elementData = flow.stack.GetElementData<Data>(this);
			for (int i = 0; i < elementData.inputsActivated.Length; i++)
			{
				if (!elementData.inputsActivated[i])
				{
					return false;
				}
			}
			return true;
		}

		private IEnumerator EnterCoroutine(Flow flow, int index)
		{
			Data data = flow.stack.GetElementData<Data>(this);
			data.inputsActivated[index] = true;
			if (data.isWaitingCoroutine)
			{
				yield break;
			}
			if (!CheckActivated(flow))
			{
				data.isWaitingCoroutine = true;
				yield return new WaitUntil(() => CheckActivated(flow));
				data.isWaitingCoroutine = false;
			}
			if (resetOnExit)
			{
				Reset(flow);
			}
			yield return exit;
		}

		private ControlOutput Reset(Flow flow)
		{
			Data elementData = flow.stack.GetElementData<Data>(this);
			for (int i = 0; i < elementData.inputsActivated.Length; i++)
			{
				elementData.inputsActivated[i] = false;
			}
			return null;
		}
	}
}
