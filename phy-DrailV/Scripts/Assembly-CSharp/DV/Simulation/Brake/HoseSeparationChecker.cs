using System.Collections.Generic;
using DV.MultipleUnit;
using DV.Utils;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class HoseSeparationChecker : SingletonBehaviour<HoseSeparationChecker>
	{
		private struct BrakeHoseCheckPair
		{
			public HoseAndCock a;

			public HoseAndCock b;
		}

		private struct MUCableCheckPair
		{
			public MultipleUnitCable a;

			public MultipleUnitCable b;
		}

		public const float BREAK_DISTANCE_THRESHOLD = 1.4f;

		private const float BREAK_DISTANCE_THRESHOLD_SQR = 1.9599999f;

		private readonly List<BrakeHoseCheckPair> brakeHosesToCheck = new List<BrakeHoseCheckPair>();

		private readonly List<MUCableCheckPair> muCablesToCheck = new List<MUCableCheckPair>();

		public new static string AllowAutoCreate()
		{
			return "[HoseSeparationChecker]";
		}

		private void OnEnable()
		{
			Brakeset.HoseConnectionChanged += OnBrakeHoseConnectionChanged;
			Trainset.TrainsetsChanged += OnTrainsetsChanged;
			MultipleUnitCable.AnyConnectionChanged += OnMUCableConnectionChanged;
		}

		private void OnDisable()
		{
			Brakeset.HoseConnectionChanged -= OnBrakeHoseConnectionChanged;
			Trainset.TrainsetsChanged -= OnTrainsetsChanged;
			MultipleUnitCable.AnyConnectionChanged -= OnMUCableConnectionChanged;
		}

		private void Update()
		{
			if (!SingletonBehaviour<AppUtil>.Instance.IsTimePausedSafer)
			{
				Brakeset.TickAll(Time.deltaTime);
				CheckDistances();
			}
		}

		private void OnBrakeHoseConnectionChanged(bool connected, HoseAndCock a, HoseAndCock b)
		{
			if (connected)
			{
				int id = a.parentSystem.GetComponent<TrainCar>().trainset.id;
				int id2 = b.parentSystem.GetComponent<TrainCar>().trainset.id;
				if (id != id2)
				{
					brakeHosesToCheck.Add(new BrakeHoseCheckPair
					{
						a = a,
						b = b
					});
				}
				return;
			}
			for (int num = brakeHosesToCheck.Count - 1; num >= 0; num--)
			{
				BrakeHoseCheckPair brakeHoseCheckPair = brakeHosesToCheck[num];
				if ((brakeHoseCheckPair.a == a && brakeHoseCheckPair.b == b) || (brakeHoseCheckPair.a == b && brakeHoseCheckPair.b == a))
				{
					brakeHosesToCheck.RemoveAt(num);
				}
			}
		}

		private void OnMUCableConnectionChanged(bool connected, MultipleUnitCable a, MultipleUnitCable b)
		{
			if (connected)
			{
				int id = a.muModule.train.trainset.id;
				int id2 = b.muModule.train.trainset.id;
				if (id != id2)
				{
					muCablesToCheck.Add(new MUCableCheckPair
					{
						a = a,
						b = b
					});
				}
				return;
			}
			for (int num = muCablesToCheck.Count - 1; num >= 0; num--)
			{
				MUCableCheckPair mUCableCheckPair = muCablesToCheck[num];
				if ((mUCableCheckPair.a == a && mUCableCheckPair.b == b) || (mUCableCheckPair.a == b && mUCableCheckPair.b == a))
				{
					muCablesToCheck.RemoveAt(num);
				}
			}
		}

		private void OnTrainsetsChanged(bool merged)
		{
			if (merged)
			{
				for (int num = brakeHosesToCheck.Count - 1; num >= 0; num--)
				{
					BrakeHoseCheckPair brakeHoseCheckPair = brakeHosesToCheck[num];
					int id = brakeHoseCheckPair.a.parentSystem.GetComponent<TrainCar>().trainset.id;
					int id2 = brakeHoseCheckPair.b.parentSystem.GetComponent<TrainCar>().trainset.id;
					if (id == id2)
					{
						brakeHosesToCheck.RemoveAt(num);
					}
				}
				for (int num2 = muCablesToCheck.Count - 1; num2 >= 0; num2--)
				{
					MUCableCheckPair mUCableCheckPair = muCablesToCheck[num2];
					int id3 = mUCableCheckPair.a.muModule.train.trainset.id;
					int id4 = mUCableCheckPair.b.muModule.train.trainset.id;
					if (id3 == id4)
					{
						muCablesToCheck.RemoveAt(num2);
					}
				}
				return;
			}
			Trainset trainset = Trainset.allSets[Trainset.allSets.Count - 2];
			Trainset trainset2 = Trainset.allSets[Trainset.allSets.Count - 1];
			Coupler endmost = trainset.GetEndmost(front: true);
			Coupler endmost2 = trainset.GetEndmost(front: false);
			Coupler endmost3 = trainset2.GetEndmost(front: true);
			Coupler endmost4 = trainset2.GetEndmost(front: false);
			HoseAndCock hoseAndCock = endmost.hoseAndCock;
			HoseAndCock hoseAndCock2 = endmost2.hoseAndCock;
			HoseAndCock hoseAndCock3 = endmost3.hoseAndCock;
			HoseAndCock hoseAndCock4 = endmost4.hoseAndCock;
			if (hoseAndCock.IsHoseConnected && hoseAndCock.connectedTo == hoseAndCock3)
			{
				brakeHosesToCheck.Add(new BrakeHoseCheckPair
				{
					a = hoseAndCock,
					b = hoseAndCock3
				});
			}
			else if (hoseAndCock.IsHoseConnected && hoseAndCock.connectedTo == hoseAndCock4)
			{
				brakeHosesToCheck.Add(new BrakeHoseCheckPair
				{
					a = hoseAndCock,
					b = hoseAndCock4
				});
			}
			else if (hoseAndCock2.IsHoseConnected && hoseAndCock2.connectedTo == hoseAndCock3)
			{
				brakeHosesToCheck.Add(new BrakeHoseCheckPair
				{
					a = hoseAndCock2,
					b = hoseAndCock3
				});
			}
			else if (hoseAndCock2.IsHoseConnected && hoseAndCock2.connectedTo == hoseAndCock4)
			{
				brakeHosesToCheck.Add(new BrakeHoseCheckPair
				{
					a = hoseAndCock2,
					b = hoseAndCock4
				});
			}
			MultipleUnitCable multipleUnitCable = null;
			if (endmost.train.IsMultipleUnit)
			{
				MultipleUnitModule muModule = endmost.train.muModule;
				multipleUnitCable = (endmost.isFrontCoupler ? muModule.frontCableAdapter.muCable : muModule.rearCableAdapter.muCable);
			}
			MultipleUnitCable multipleUnitCable2 = null;
			if (endmost2.train.IsMultipleUnit)
			{
				MultipleUnitModule muModule2 = endmost2.train.muModule;
				multipleUnitCable2 = (endmost2.isFrontCoupler ? muModule2.frontCableAdapter.muCable : muModule2.rearCableAdapter.muCable);
			}
			MultipleUnitCable multipleUnitCable3 = null;
			if (endmost3.train.IsMultipleUnit)
			{
				MultipleUnitModule muModule3 = endmost3.train.muModule;
				multipleUnitCable3 = (endmost3.isFrontCoupler ? muModule3.frontCableAdapter.muCable : muModule3.rearCableAdapter.muCable);
			}
			MultipleUnitCable multipleUnitCable4 = null;
			if (endmost4.train.IsMultipleUnit)
			{
				MultipleUnitModule muModule4 = endmost4.train.muModule;
				multipleUnitCable4 = (endmost4.isFrontCoupler ? muModule4.frontCableAdapter.muCable : muModule4.rearCableAdapter.muCable);
			}
			if ((multipleUnitCable != null || multipleUnitCable2 != null) && (multipleUnitCable3 != null || multipleUnitCable4 != null))
			{
				if (multipleUnitCable != null && multipleUnitCable.IsConnected && multipleUnitCable.connectedTo == multipleUnitCable3)
				{
					muCablesToCheck.Add(new MUCableCheckPair
					{
						a = multipleUnitCable,
						b = multipleUnitCable3
					});
				}
				else if (multipleUnitCable != null && multipleUnitCable.IsConnected && multipleUnitCable.connectedTo == multipleUnitCable4)
				{
					muCablesToCheck.Add(new MUCableCheckPair
					{
						a = multipleUnitCable,
						b = multipleUnitCable4
					});
				}
				else if (multipleUnitCable2 != null && multipleUnitCable2.IsConnected && multipleUnitCable2.connectedTo == multipleUnitCable3)
				{
					muCablesToCheck.Add(new MUCableCheckPair
					{
						a = multipleUnitCable2,
						b = multipleUnitCable3
					});
				}
				else if (multipleUnitCable2 != null && multipleUnitCable2.IsConnected && multipleUnitCable2.connectedTo == multipleUnitCable4)
				{
					muCablesToCheck.Add(new MUCableCheckPair
					{
						a = multipleUnitCable2,
						b = multipleUnitCable4
					});
				}
			}
		}

		private void CheckDistances()
		{
			if (Trainset.allSets.Count == 0 || Brakeset.allSets.Count == 0)
			{
				return;
			}
			for (int num = brakeHosesToCheck.Count - 1; num >= 0; num--)
			{
				BrakeHoseCheckPair brakeHoseCheckPair = brakeHosesToCheck[num];
				BrakeSystem parentSystem = brakeHoseCheckPair.a.parentSystem;
				BrakeSystem parentSystem2 = brakeHoseCheckPair.b.parentSystem;
				if (parentSystem == null || parentSystem2 == null)
				{
					brakeHosesToCheck.RemoveAt(num);
				}
				else
				{
					TrainCar component = parentSystem.GetComponent<TrainCar>();
					TrainCar component2 = parentSystem2.GetComponent<TrainCar>();
					Coupler coupler = (brakeHoseCheckPair.a.isFront ? component.frontCoupler : component.rearCoupler);
					Coupler c = (brakeHoseCheckPair.b.isFront ? component2.frontCoupler : component2.rearCoupler);
					CouplingHoseRig rig = CouplingHoseRig.GetRig(coupler);
					CouplingHoseRig rig2 = CouplingHoseRig.GetRig(c);
					if ((bool)rig && (bool)rig2 && Vector3.SqrMagnitude(rig.ropeAnchor.position - rig2.ropeAnchor.position) > 1.9599999f)
					{
						Debug.Log("Breaking hose connection due to separation", this);
						coupler.DisconnectAirHose(playAudio: true);
					}
				}
			}
			for (int num2 = muCablesToCheck.Count - 1; num2 >= 0; num2--)
			{
				MUCableCheckPair mUCableCheckPair = muCablesToCheck[num2];
				MultipleUnitModule muModule = mUCableCheckPair.a.muModule;
				MultipleUnitModule muModule2 = mUCableCheckPair.b.muModule;
				if (muModule == null || muModule2 == null)
				{
					Debug.LogError(string.Format("Encountered null for {0} a: {1} b: {2}, removing pair", "MultipleUnitModule", muModule == null, muModule2 == null));
					muCablesToCheck.RemoveAt(num2);
				}
				else
				{
					CouplingHoseRig couplingHoseRig = mUCableCheckPair.a.HoseAdapter?.rig;
					CouplingHoseRig couplingHoseRig2 = mUCableCheckPair.b.HoseAdapter?.rig;
					if ((bool)couplingHoseRig && (bool)couplingHoseRig2 && Vector3.SqrMagnitude(couplingHoseRig.ropeAnchor.position - couplingHoseRig2.ropeAnchor.position) > 1.9599999f)
					{
						Debug.Log("Breaking MU hose connection due to separation", this);
						mUCableCheckPair.a.Disconnect(playAudio: true);
					}
				}
			}
		}
	}
}
