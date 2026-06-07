using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Logic.Factory;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/CounterBehaviour", fileName = "CounterBehaviour", order = 0)]
	public class CounterBehaviour : ResourceHolderBehaviour
	{
		public struct CalibratingValues
		{
			public bool IsCalibrating;

			public bool IsBlocked;

			public float CalibrationProgress;

			public CalibratingValues(bool isCalibrating, bool isBlocked, float calibrationProgress)
			{
				IsCalibrating = isCalibrating;
				IsBlocked = isBlocked;
				CalibrationProgress = calibrationProgress;
			}
		}

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private int _histogramDuration = 120;

		private Queue<bool> _histogram = new Queue<bool>();

		private Queue<int> _averages = new Queue<int>();

		private int _counter;

		private int _maxHistogramLength;

		private int _calibrationCounter;

		private bool _outputResourceSuccessfully = true;

		public MainThreadEvent<float> OnCounterUpdated = new MainThreadEvent<float>();

		public MainThreadEvent<CalibratingValues> OnCalibrating = new MainThreadEvent<CalibratingValues>();

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			SetShouldClearInputBufferOnOutput();
			base.VariableUpdateFrequency.ValueChanged += InitMaxLength;
			CounterBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<CounterBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				ApplySaveState(behaviourSaveStateDto);
			}
		}

		public override void UnInit()
		{
			base.VariableUpdateFrequency.ValueChanged -= InitMaxLength;
			base.UnInit();
		}

		public override void HandleOutputResource(Resource resource, int outputIndex)
		{
			_outputResourceSuccessfully = true;
			base.HandleOutputResource(resource, outputIndex);
		}

		public override void Update()
		{
			InitMaxLength();
			if (!HasOutputResourceHolder(0))
			{
				UpdateNoOutput();
				return;
			}
			bool flag = IsInputBufferFull();
			bool flag2 = flag && _outputResourceSuccessfully;
			_histogram.Enqueue(flag2);
			if (flag2)
			{
				_counter++;
			}
			UpdateCalibration();
			while (_histogram.Count > _maxHistogramLength)
			{
				if (_histogram.Dequeue())
				{
					_counter--;
				}
				_averages.Dequeue();
			}
			_averages.Enqueue(_counter);
			int num = 0;
			foreach (int average in _averages)
			{
				num += average;
			}
			float data = (float)num / (float)_averages.Count;
			OnCounterUpdated.Fire(data);
			if (flag)
			{
				_outputResourceSuccessfully = false;
			}
			TryOutput();
		}

		private void UpdateNoOutput()
		{
			OnCounterUpdated.Fire(0f);
			OnCalibrating.Fire(new CalibratingValues(isCalibrating: true, isBlocked: true, 0f));
			_counter = 0;
			_histogram.Clear();
			_averages.Clear();
		}

		private void InitMaxLength(int _)
		{
			_maxHistogramLength = FactoryUpdater.Instance.GetStepsPerSecond() * _histogramDuration / base.UpdateFrequency;
		}

		private void InitMaxLength()
		{
			if (_maxHistogramLength == 0)
			{
				_maxHistogramLength = FactoryUpdater.Instance.GetStepsPerSecond() * _histogramDuration / base.UpdateFrequency;
			}
		}

		private void UpdateCalibration()
		{
			bool flag = _calibrationCounter < 2 * _maxHistogramLength;
			if (flag)
			{
				_calibrationCounter++;
			}
			float calibrationProgress = (float)_calibrationCounter / (2f * (float)_maxHistogramLength);
			OnCalibrating.Fire(new CalibratingValues(flag, isBlocked: false, calibrationProgress));
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			base.AddResource(resource, inputData);
			StartActivity();
		}

		private void TryOutput()
		{
			if (!IsTryingToOutput() && IsInputBufferFull())
			{
				EndActivity();
				TryOutput(GetResourceInInputBuffer(), 0);
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new CounterBehaviourSaveStateDto
			{
				InputBufferSaveData = GetInputBufferSaveData(),
				Histogram = new Queue<bool>(_histogram),
				Averages = new Queue<int>(_averages),
				CalibrationCounter = _calibrationCounter,
				Counter = _counter
			};
		}

		private void ApplySaveState(CounterBehaviourSaveStateDto saveStateDto)
		{
			ApplyInputBufferSaveData(saveStateDto.InputBufferSaveData, _resourceFactory, _resourceDatabase);
			_histogram = new Queue<bool>(saveStateDto.Histogram);
			_averages = new Queue<int>(saveStateDto.Averages);
			_counter = saveStateDto.Counter;
			_calibrationCounter = saveStateDto.CalibrationCounter;
		}
	}
}
