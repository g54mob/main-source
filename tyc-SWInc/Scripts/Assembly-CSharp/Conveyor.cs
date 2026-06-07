using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
	public Furniture Parent;

	public Transform ConnectionPos;

	public Transform AltConnectionPos;

	public bool InputSecondRoom;

	public bool InputSecondRoomAlt;

	public bool HasAltInput;

	public bool TakesInput = true;

	public bool PalletOutput;

	public bool PalletInput;

	public bool InstaNotify;

	public bool SnapOutput;

	public bool PalletToInput;

	public bool DirectedInput;

	public bool Recycler;

	public bool GaragePort;

	public bool InputSetsOutput;

	public bool AutoRoute;

	public bool AllowFlow = true;

	public bool CanBeDeadEnd = true;

	public Transform[] OutputPos;

	public bool[] OutputSecondRoom;

	[SerializeField]
	private Conveyor[] Outputs;

	private Conveyor OutputPallet;

	[NonSerialized]
	public int[] OutputMasks;

	[NonSerialized]
	public HashSet<Conveyor> Inputs = new HashSet<Conveyor>();

	public BeltScript[] Belts;

	[NonSerialized]
	public IManufacturingConverter Converter;

	[NonSerialized]
	public int CurrentOutput;

	public Transform[] ConveyorPoints;

	private Vector3[] _cachedPoints;

	[NonSerialized]
	public Vector3 CachedConnectionPos = Vector3.zero;

	public float Speed = 1f;

	[NonSerialized]
	public int[] Recycled;

	[NonSerialized]
	public int[] NonRecycled;

	[NonSerialized]
	private int _currentHour;

	[NonSerialized]
	private int _currentRecycled;

	[NonSerialized]
	private int _currentNonRecycled;

	[NonSerialized]
	public bool HadRecycler;

	public bool IsVisualInputOutput = true;

	public bool IsVisualPerpOutput = true;

	[NonSerialized]
	public bool Blocked;

	public List<MeshRenderer> BeltRends = new List<MeshRenderer>();

	[NonSerialized]
	public int Group;

	[NonSerialized]
	public int Number;

	private bool _reverseOutput;

	[NonSerialized]
	public TransportBox[] CurrentBoxes;

	private static HashSet<Conveyor> _palletOutputCache = new HashSet<Conveyor>();

	private static HashSet<Conveyor> _traverseVisited = new HashSet<Conveyor>();

	private static List<ValueTuple<Conveyor, int>> _conveyorCache = new List<ValueTuple<Conveyor, int>>();

	private static HashSet<Conveyor> _connectionCache = new HashSet<Conveyor>();

	public int Floor
	{
		get
		{
			return Parent.GetFloor();
		}
	}

	public bool ReverseOutput
	{
		get
		{
			return _reverseOutput;
		}
		set
		{
			if (_reverseOutput != value)
			{
				_reverseOutput = value;
				UpdateCachedPoints();
			}
		}
	}

	public int OutputLength
	{
		get
		{
			if (!InputSetsOutput)
			{
				return Outputs.Length;
			}
			return 1;
		}
	}

	public void UpdateBeltRends()
	{
		float num = Speed * Parent.BoostValue;
		Material sharedMaterial = (Parent.IsOn ? TimeOfDay.Instance.BeltMats[Mathf.Clamp(Mathf.RoundToInt(num - 1f), 0, TimeOfDay.Instance.BeltMats.Length - 1)] : TimeOfDay.Instance.BeltMatNoMove);
		for (int i = 0; i < BeltRends.Count; i++)
		{
			BeltRends[i].sharedMaterial = sharedMaterial;
		}
	}

	public bool HasAnyOutput()
	{
		if (!Outputs.Any((Conveyor x) => x != null))
		{
			return !OutputPallet.IsReferenceNull();
		}
		return true;
	}

	public Conveyor GetOutput(int i)
	{
		lock (Outputs)
		{
			return Outputs[(!InputSetsOutput) ? i : (ReverseOutput ? 1 : 0)];
		}
	}

	private void SetOutput(int i, Conveyor c)
	{
		lock (Outputs)
		{
			Outputs[i] = c;
		}
	}

	public bool IsEmpty()
	{
		if (CurrentBoxes != null)
		{
			for (int i = 0; i < CurrentBoxes.Length; i++)
			{
				if (CurrentBoxes[i] != null)
				{
					return false;
				}
			}
		}
		return true;
	}

	public bool CanTake()
	{
		if (!(Parent.Pallet == null))
		{
			return Parent.Pallet.CanTakeOrder();
		}
		return true;
	}

	private void Awake()
	{
		CurrentBoxes = new TransportBox[ConveyorPoints.Length];
		OutputMasks = new int[Outputs.Length];
		for (int i = 0; i < OutputMasks.Length; i++)
		{
			OutputMasks[i] = -1;
		}
		Converter = GetComponent<IManufacturingConverter>();
	}

	private void Start()
	{
		if (Parent.isTemporary)
		{
			return;
		}
		if (Recycler && Parent.Map == null)
		{
			lock (GameSettings.Instance.Recyclers)
			{
				GameSettings.Instance.Recyclers.Add(this);
			}
		}
		UpdateBeltRends();
	}

	public Vector3 GetCachedPoint(int i)
	{
		lock (this)
		{
			if (i < 0 || _cachedPoints == null || i >= _cachedPoints.Length)
			{
				return Vector3.zero;
			}
			return _cachedPoints[i];
		}
	}

	public void UpdateCachedPoints()
	{
		lock (this)
		{
			if (_cachedPoints == null || _cachedPoints.Length != ConveyorPoints.Length)
			{
				_cachedPoints = ConveyorPoints.SelectInPlace((Transform x) => x.position);
			}
			else
			{
				for (int num = 0; num < _cachedPoints.Length; num++)
				{
					_cachedPoints[num] = ConveyorPoints[num].position;
				}
			}
			if (ReverseOutput)
			{
				_cachedPoints.ReverseArray();
			}
			CachedConnectionPos = (HasAltInput ? ((ConnectionPos.position + AltConnectionPos.position) * 0.5f) : ConnectionPos.position);
		}
	}

	public void NextHour()
	{
		if (Recycled == null)
		{
			Recycled = new int[24];
			NonRecycled = new int[24];
		}
		Recycled[_currentHour] = _currentRecycled;
		NonRecycled[_currentHour] = _currentNonRecycled;
		_currentHour = (_currentHour + 1) % 24;
		_currentRecycled = 0;
		_currentNonRecycled = 0;
	}

	public void AddRecycled(bool recycled)
	{
		if (Recycled == null)
		{
			Recycled = new int[24];
			NonRecycled = new int[24];
		}
		if (recycled)
		{
			_currentRecycled++;
			if (_currentRecycled > 10)
			{
				HintController.Show(HintController.Hints.HintManufacturingSpace);
			}
		}
		else
		{
			_currentNonRecycled++;
		}
	}

	public bool NotifyBox(TransportBox box, bool holding)
	{
		if (Recycler)
		{
			ManufactureOrder manufactureOrder = box.Order as ManufactureOrder;
			AddRecycled(manufactureOrder != null);
			if (manufactureOrder != null)
			{
				manufactureOrder.Recycle();
				Parent.StartInteraction = true;
				return true;
			}
		}
		if (Converter != null)
		{
			return Converter.TakeOrder(box);
		}
		return false;
	}

	public Conveyor GetOutput(IProductOrder order, int point, bool forBox, float wait = -1f)
	{
		bool wasBlockedByBox;
		return GetOutput(order, point, forBox, out wasBlockedByBox, wait);
	}

	public Conveyor GetOutput(IProductOrder order, int point, bool forBox, out bool wasBlockedByBox, float wait = -1f)
	{
		wasBlockedByBox = false;
		if (forBox && Parent.DefaultOn && !Parent.IsOn)
		{
			return null;
		}
		if (Outputs.Length != 0)
		{
			if (AutoRoute && order is ManufactureOrder)
			{
				ManufactureOrder manufactureOrder = (ManufactureOrder)order;
				for (int i = 0; i <= OutputMasks.Length; i++)
				{
					if ((OutputMasks[CurrentOutput] & manufactureOrder.Mask) != 0)
					{
						break;
					}
					CurrentOutput++;
					if (CurrentOutput >= OutputMasks.Length)
					{
						CurrentOutput = 0;
					}
				}
			}
			Conveyor conveyor;
			lock (Outputs)
			{
				conveyor = Outputs[(!InputSetsOutput) ? CurrentOutput : (ReverseOutput ? 1 : 0)];
			}
			if (!InputSetsOutput && Outputs.Length > 1)
			{
				CurrentOutput = (CurrentOutput + 1) % Outputs.Length;
			}
			if (conveyor != null && conveyor.Parent.Printer != null && !conveyor.Parent.Printer.AcceptInput())
			{
				conveyor = null;
			}
			if (conveyor != null)
			{
				if ((point >= 0 && conveyor.CurrentBoxes[point] == null) || (point == -1 && conveyor.CurrentBoxes.All((TransportBox x) => x == null)))
				{
					if (conveyor.Parent.Pallet != null && (!conveyor.Parent.Pallet.CanTakeOrder() || !(order is ProductPrintOrder)))
					{
						if (order is ProductPrintOrder)
						{
							UpdateBlockStatus();
							return CheckPalletOutput();
						}
						SetBlocked();
						return null;
					}
					UpdateBlockStatus();
					return conveyor;
				}
				wasBlockedByBox = true;
			}
		}
		if (order is ProductPrintOrder)
		{
			UpdateBlockStatus();
			if (!Outputs.All((Conveyor x) => x == null) && !(wait < 0f) && !(wait > 0.25f))
			{
				return null;
			}
			return CheckPalletOutput();
		}
		SetBlocked();
		return null;
	}

	private void SetBlocked()
	{
		try
		{
			bool flag = HasPalletOutput();
			for (int i = 0; i < Outputs.Length; i++)
			{
				if (Outputs[i] != null)
				{
					if (!(Outputs[i].Parent.Pallet != null))
					{
						flag = false;
						break;
					}
					flag = true;
				}
			}
			if (flag)
			{
				lock (HUD.Instance.ConveyorBlocked)
				{
					HUD.Instance.BlockChanged |= HUD.Instance.ConveyorBlocked.Add(this);
					Blocked = true;
					return;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void UpdateBlockStatus()
	{
		if (!Blocked)
		{
			return;
		}
		try
		{
			lock (HUD.Instance.ConveyorBlocked)
			{
				HUD.Instance.ConveyorBlocked.Remove(this);
				Blocked = false;
			}
		}
		catch (Exception)
		{
		}
	}

	private Conveyor CheckPalletOutput()
	{
		if (OutputPallet != null && OutputPallet.Parent.Pallet.CanTakeOrder())
		{
			return OutputPallet;
		}
		return null;
	}

	private bool HasPalletOutput()
	{
		return OutputPallet != null;
	}

	public Conveyor GetPalletOutput()
	{
		return OutputPallet;
	}

	public Conveyor GetParentConveyor()
	{
		if (Parent.IsSnapping && Parent.SnappedTo != null && Parent.SnappedTo.Parent.HasConveyor)
		{
			return Parent.SnappedTo.Parent.Conveyor;
		}
		return null;
	}

	private void ResetBox()
	{
		for (int i = 0; i < CurrentBoxes.Length; i++)
		{
			TransportBox transportBox = CurrentBoxes[i];
			if (transportBox == null)
			{
				continue;
			}
			lock (transportBox)
			{
				transportBox.Progress = 0f;
				transportBox.CPoint = i;
				if (transportBox.From == this)
				{
					transportBox.To = null;
				}
				else
				{
					transportBox.From = null;
				}
			}
		}
	}

	public void AddInput(Conveyor input)
	{
		lock (Inputs)
		{
			Inputs.Add(input);
		}
	}

	public void RemoveInput(Conveyor input)
	{
		lock (Inputs)
		{
			Inputs.Remove(input);
		}
	}

	public static bool WithinDist(Vector3 p, Vector3 pp)
	{
		if (Mathf.Abs(pp.x - p.x) < 0.71f)
		{
			return Mathf.Abs(pp.z - p.z) < 0.71f;
		}
		return false;
	}

	public void ConnectUp(HashSet<Furniture> _starts)
	{
		if (PalletToInput)
		{
			_starts.Remove(Parent);
			return;
		}
		bool flag = !Parent.IsActuallyPlayerControlled();
		if (PalletToInput)
		{
			_palletOutputCache.Clear();
			flag = true;
			Vector3 position = base.transform.position;
			int i = Outputs.Length;
			bool flag2 = false;
			for (int j = 0; j < Outputs.Length; j++)
			{
				Conveyor conveyor = Outputs[j];
				if (conveyor != null)
				{
					if (WithinDist(conveyor.ConnectionPos.position, position))
					{
						_starts.Remove(conveyor.Parent);
						_palletOutputCache.Add(conveyor);
						continue;
					}
					conveyor.RemoveInput(this);
				}
				i = Math.Min(i, j);
				SetOutput(j, null);
				flag2 = true;
				GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(this);
			}
			if (i < Outputs.Length)
			{
				HashList<Furniture> furniture = Parent.Parent.GetFurniture("PalletConnection");
				for (int k = 0; k < furniture.Count; k++)
				{
					Furniture furniture2 = furniture[k];
					if (furniture2.Conveyor.PalletInput && !_palletOutputCache.Contains(furniture2.Conveyor) && WithinDist(furniture2.Conveyor.ConnectionPos.position, position))
					{
						_starts.Remove(furniture2);
						SetOutput(i, furniture2.Conveyor);
						flag2 = true;
						furniture2.Conveyor.AddInput(this);
						GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(this);
						for (i++; i < Outputs.Length && !Outputs[i].IsReferenceNull(); i++)
						{
						}
						if (i >= Outputs.Length)
						{
							break;
						}
					}
				}
			}
			if (flag2 && Parent.Pallet != null)
			{
				Parent.Pallet.RefreshReach();
			}
		}
		else if (SnapOutput)
		{
			bool flag3 = false;
			if (Outputs[0] != null)
			{
				Conveyor conveyor2 = Outputs[0];
				if (conveyor2.Parent == Parent.SnappedTo.Parent)
				{
					_starts.Remove(conveyor2.Parent);
					flag = true;
					flag3 = true;
				}
				else
				{
					conveyor2.RemoveInput(this);
					SetOutput(0, null);
					GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(this);
				}
			}
			if (!flag3)
			{
				Furniture parent = Parent.SnappedTo.Parent;
				if (parent != null && parent.HasConveyor)
				{
					_starts.Remove(parent);
					flag = true;
					SetOutput(0, parent.Conveyor);
					parent.Conveyor.AddInput(this);
					GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(this);
				}
			}
		}
		else
		{
			bool flag4 = false;
			if ((InputSecondRoom || InputSecondRoomAlt) && Parent.ExtraParent != null)
			{
				Parent.ExtraParent.DirtyConveyors = true;
			}
			if (Outputs.Length != 0)
			{
				for (int l = 0; l < Outputs.Length; l++)
				{
					Conveyor conveyor3 = Outputs[l];
					if (conveyor3 != null)
					{
						bool alt = false;
						if (MatchConveyor(conveyor3, out alt, l, OutputPos[l].position, OutputPos[l].rotation.eulerAngles.y))
						{
							if (!InputSetsOutput && conveyor3.InputSetsOutput)
							{
								TraverseOutputs(conveyor3, this, l);
							}
							flag = true;
							_starts.Remove(conveyor3.Parent);
							continue;
						}
						if (!OutputSecondRoom[l] && (conveyor3.InputSecondRoom || (conveyor3.HasAltInput && conveyor3.InputSecondRoomAlt)))
						{
							conveyor3.Parent.Parent.DirtyConveyors = true;
						}
						if (!flag4)
						{
							flag4 = true;
							ResetBox();
						}
						conveyor3.ResetBox();
						conveyor3.RemoveInput(this);
						GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(this);
					}
					SetOutput(l, null);
				}
				for (int m = 0; m < OutputPos.Length; m++)
				{
					if (!Outputs[m].IsReferenceNull())
					{
						continue;
					}
					Vector3 position2 = OutputPos[m].position;
					float y = OutputPos[m].rotation.eulerAngles.y;
					List<Furniture> furnitures = (OutputSecondRoom[m] ? Parent.ExtraParent : Parent.Parent).GetFurnitures();
					for (int n = 0; n < furnitures.Count; n++)
					{
						Furniture furniture3 = furnitures[n];
						if (!(furniture3 != Parent) || !furniture3.HasConveyor || !furniture3.Conveyor.TakesInput)
						{
							continue;
						}
						bool alt2 = false;
						if (!MatchConveyor(furniture3.Conveyor, out alt2, m, position2, y))
						{
							continue;
						}
						flag = true;
						if (!flag4)
						{
							flag4 = true;
							ResetBox();
						}
						furniture3.Conveyor.ResetBox();
						_starts.Remove(furniture3);
						SetOutput(m, furniture3.Conveyor);
						furniture3.Conveyor.AddInput(this);
						if (OutputSecondRoom[m])
						{
							if (Parent.ExtraParent != null)
							{
								Parent.ExtraParent.DirtyConveyors = true;
							}
						}
						else if (furniture3.Conveyor.IsInputSecond(alt2))
						{
							furniture3.Parent.DirtyConveyors = true;
						}
						if (!InputSetsOutput && furniture3.Conveyor.InputSetsOutput)
						{
							TraverseOutputs(furniture3.Conveyor, this, m);
						}
						GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(this);
						break;
					}
				}
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				flag = HasPalletOutput();
			}
		}
		if (flag)
		{
			HUD.Instance.ConveyorNoOutput.Remove(this);
		}
		else if (CanBeDeadEnd)
		{
			HUD.Instance.ConveyorNoOutput.Add(this);
		}
	}

	private void DoubleCheckConnected()
	{
		if (!CanBeDeadEnd || !Parent.IsActuallyPlayerControlled() || OutputPallet != null)
		{
			HUD.Instance.ConveyorNoOutput.Remove(this);
			return;
		}
		for (int i = 0; i < OutputLength; i++)
		{
			if (GetOutput(i) != null)
			{
				HUD.Instance.ConveyorNoOutput.Remove(this);
				return;
			}
		}
		HUD.Instance.ConveyorNoOutput.Add(this);
	}

	public void CheckFacingSelf()
	{
		if (CanBeDeadEnd && !HUD.Instance.ConveyorNoOutput.Contains(this) && OutputLength == 1 && GetOutput(0) != null && GetOutput(0).OutputLength == 1 && GetOutput(0).GetOutput(0) == this)
		{
			HUD.Instance.ConveyorNoOutput.Add(this);
		}
	}

	public static void TraverseOutputs(Conveyor o, Conveyor input, int output)
	{
		_traverseVisited.Add(o);
		do
		{
			bool alt;
			input.MatchConveyor(o, out alt, output, input.OutputPos[output].position, input.OutputPos[output].rotation.eulerAngles.y);
			o.ReverseOutput = alt;
			output = (alt ? 1 : 0);
			input = o;
			o = o.Outputs[output];
		}
		while (o != null && o.InputSetsOutput && _traverseVisited.Add(o));
		_traverseVisited.Clear();
	}

	public bool IsInputSecond(bool alt)
	{
		if (!alt)
		{
			return InputSecondRoom;
		}
		if (HasAltInput)
		{
			return InputSecondRoomAlt;
		}
		return false;
	}

	private bool MatchConveyor(Conveyor other, out bool alt, int output, Vector3 p, float rot)
	{
		alt = false;
		if (MatchRoom(other, false, output) && Connects(p, rot, other, false))
		{
			return true;
		}
		if (other.HasAltInput && MatchRoom(other, true, output) && Connects(p, rot, other, true))
		{
			alt = true;
			return true;
		}
		return false;
	}

	private static bool Connects(Vector3 p, float rot, Conveyor other, bool alt)
	{
		Transform transform = (alt ? other.AltConnectionPos : other.ConnectionPos);
		Vector3 position = transform.position;
		float num = p.x - position.x;
		float num2 = p.y - position.y;
		float num3 = p.z - position.z;
		if (num > -0.2f && num < 0.2f && num3 > -0.2f && num3 < 0.2f && num2 > -0.05f && num2 < 0.05f)
		{
			if (other.DirectedInput)
			{
				return rot.Appx(transform.rotation.eulerAngles.y);
			}
			return true;
		}
		return false;
	}

	public bool MatchRoom(Conveyor other, bool alt, int output)
	{
		if (alt ? other.InputSecondRoomAlt : other.InputSecondRoom)
		{
			if (OutputSecondRoom[output])
			{
				return other.Parent.ExtraParent == Parent.ExtraParent;
			}
			return other.Parent.ExtraParent == Parent.Parent;
		}
		if (OutputSecondRoom[output])
		{
			return other.Parent.Parent == Parent.ExtraParent;
		}
		return other.Parent.Parent == Parent.Parent;
	}

	public void UpdateBelts()
	{
		if (Belts.Length == 0)
		{
			return;
		}
		bool cIn = false;
		bool cOut = false;
		bool pOut = false;
		bool cIn2 = false;
		bool cOut2 = false;
		float y = ConnectionPos.rotation.eulerAngles.y;
		if (TakesInput)
		{
			foreach (Conveyor input in Inputs)
			{
				if (!input.IsVisualInputOutput)
				{
					continue;
				}
				for (int i = 0; i < input.OutputPos.Length; i++)
				{
					if (input.Outputs[i] == this && (input.OutputPos[i].position - ConnectionPos.position).sqrMagnitude < 0.01f)
					{
						float y2 = input.OutputPos[i].rotation.eulerAngles.y;
						if (y2.Appx(y))
						{
							cIn = true;
						}
						else if (Mathf.DeltaAngle(y2, y - 90f).Appx(0f))
						{
							cOut2 = true;
						}
						else if (Mathf.DeltaAngle(y2, y + 90f).Appx(0f))
						{
							cIn2 = true;
						}
					}
				}
			}
		}
		for (int j = 0; j < Outputs.Length; j++)
		{
			if (Outputs[j] != null && Outputs[j].IsVisualInputOutput && (Outputs[j].ConnectionPos.position - OutputPos[j].position).sqrMagnitude < 0.01f)
			{
				if (Outputs[j].ConnectionPos.rotation.eulerAngles.y.Appx(OutputPos[j].rotation.eulerAngles.y))
				{
					cOut = true;
				}
				else if (Outputs[j].IsVisualPerpOutput)
				{
					pOut = true;
				}
			}
		}
		for (int k = 0; k < Belts.Length; k++)
		{
			if (Belts[k].Perpendicular)
			{
				Belts[k].UpdateBelt(cIn2, cOut2, false);
			}
			else
			{
				Belts[k].UpdateBelt(cIn, cOut, pOut);
			}
		}
	}

	private void OnDestroy()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (HUD.Instance != null)
		{
			HUD.Instance.ConveyorNoOutput.Remove(this);
			UpdateBlockStatus();
		}
		if (Recycler)
		{
			lock (GameSettings.Instance.Recyclers)
			{
				GameSettings.Instance.Recyclers.Remove(this);
			}
		}
		for (int i = 0; i < Outputs.Length; i++)
		{
			Conveyor conveyor = Outputs[i];
			if (conveyor != null)
			{
				conveyor.RemoveInput(this);
				if (i < OutputSecondRoom.Length && OutputSecondRoom[i] && Parent != null && Parent.ExtraParent != null)
				{
					Parent.ExtraParent.DirtyConveyors = true;
				}
				GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(conveyor);
			}
		}
		foreach (Conveyor input in Inputs)
		{
			GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(input);
		}
		GameSettings.Instance.BoxController.ForceAssemblyCheck = true;
		if (Parent != null && Parent.Parent != null)
		{
			Parent.Parent.DirtyConveyors = true;
		}
		for (int j = 0; j < CurrentBoxes.Length; j++)
		{
			TransportBox transportBox = CurrentBoxes[j];
			if (transportBox != null)
			{
				GameSettings.Instance.BoxController.DestroyBox(transportBox);
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		for (int i = 0; i < Mathf.Min(Outputs.Length, OutputPos.Length); i++)
		{
			if (Outputs[i] != null)
			{
				Gizmos.color = Color.cyan;
				Gizmos.DrawLine(base.transform.position, Outputs[i].ConnectionPos.position);
			}
			else
			{
				Gizmos.color = Color.red;
				Gizmos.DrawSphere(OutputPos[i].position, 0.1f);
			}
		}
	}

	public void ConnectPallet()
	{
		_conveyorCache.Clear();
		ProductPallet pallet = Parent.Pallet;
		pallet.ConnectMesh.ForEachEnum(delegate(GameObject x)
		{
			x.SetActive(false);
		});
		for (int num = 0; num < pallet.ConnectSpots.Length; num++)
		{
			Vector3 position = pallet.ConnectSpots[num].transform.position;
			List<Furniture> furnitures = Parent.Parent.GetFurnitures();
			for (int num2 = 0; num2 < furnitures.Count; num2++)
			{
				Furniture furniture = furnitures[num2];
				if (furniture.IsAliveNotNull() && furniture.HasConveyor && furniture.Conveyor.PalletOutput && furniture.transform.position.Approximate(position, 0.05f) && (furniture.Conveyor.OutputPallet == null || furniture.Conveyor.OutputPallet == this))
				{
					_conveyorCache.Add(new ValueTuple<Conveyor, int>(furniture.Conveyor, num));
					break;
				}
			}
		}
		bool flag = false;
		HashSet<int> hashSet = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
		foreach (IGrouping<int, ValueTuple<Conveyor, int>> item in from x in _conveyorCache
			group x by x.Item1.Group)
		{
			ValueTuple<Conveyor, int> valueTuple = item.MaxInstance((ValueTuple<Conveyor, int> x) => x.Item1.Number);
			hashSet.Remove(valueTuple.Item2);
			pallet.ConnectMesh[valueTuple.Item2].SetActive(true);
			Conveyor output = GetOutput(valueTuple.Item2);
			if (output != valueTuple.Item1)
			{
				if (output != null && output.OutputPallet == this)
				{
					output.OutputPallet = null;
					output.DoubleCheckConnected();
				}
				SetOutput(valueTuple.Item2, valueTuple.Item1);
				valueTuple.Item1.OutputPallet = this;
				valueTuple.Item1.AddInput(this);
				HUD.Instance.ConveyorNoOutput.Remove(valueTuple.Item1);
				flag = true;
			}
		}
		foreach (int item2 in hashSet)
		{
			Conveyor output2 = GetOutput(item2);
			if (output2 != null)
			{
				if (output2.OutputPallet == this)
				{
					output2.OutputPallet = null;
					output2.DoubleCheckConnected();
				}
				SetOutput(item2, null);
				flag = true;
			}
		}
		if (flag && Parent.Pallet != null)
		{
			Parent.Pallet.RefreshReach();
		}
		_conveyorCache.Clear();
	}

	public bool IsConnectedToPallet(bool first = true)
	{
		if (_connectionCache.Add(this))
		{
			if (Parent.Pallet != null || GetPalletOutput() != null)
			{
				if (first)
				{
					_connectionCache.Clear();
				}
				return true;
			}
			for (int i = 0; i < OutputLength; i++)
			{
				Conveyor output = GetOutput(i);
				if (output != null && output.IsConnectedToPallet(false))
				{
					if (first)
					{
						_connectionCache.Clear();
					}
					return true;
				}
			}
		}
		if (first)
		{
			_connectionCache.Clear();
		}
		return false;
	}
}
