using System;
using System.Collections.Generic;
using System.Threading;
using PInvokeSerialPort;
using TMPro;
using UnityEngine;

public class SerialModule : Module
{
	public class SerialIsActive_EventData : EventData
	{
		public bool IsActive;

		public SerialIsActive_EventData()
		{
		}

		public SerialIsActive_EventData(bool isActive)
		{
		}
	}

	public class SerialReceive_EventData : EventData
	{
		public LuaTableContent Lines;

		public byte[] Data;

		public SerialReceive_EventData()
		{
		}

		public SerialReceive_EventData(LuaTableContent lines, byte[] data)
		{
		}
	}

	public enum Commands
	{
		UpdateConnection = 1
	}

	private abstract class Job
	{
		protected SerialPort serialPort;

		public uint id;

		public Job(SerialPort serialPort)
		{
		}

		public abstract void Execute();

		public abstract void Abort();
	}

	private class WriteJob : Job, IAsyncJobVoid, IGenericAsyncJob
	{
		private byte[] data;

		private bool done;

		private bool abort;

		public Type ResultType => null;

		public WriteJob(SerialPort serialPort, byte[] data)
		{
		}

		public override void Execute()
		{
		}

		public override void Abort()
		{
		}

		public bool IsComplete()
		{
			return false;
		}
	}

	public SpriteRenderer ledLightRenderer;

	public TextMeshPro textRenderer;

	private Material ledLightMaterial;

	private Texture2D statusTexture;

	private int ledsCount;

	private ModuleProperty receiveModeProperty;

	private ModuleProperty isActiveProperty;

	private ModuleProperty portProperty;

	private ModuleProperty baudRateProperty;

	private ModuleProperty dataBitsProperty;

	private ModuleProperty parityProperty;

	private ModuleProperty stopBitsProperty;

	private Thread thread;

	private Dictionary<uint, Job> txJobs;

	private Queue<Job> txJobsQueue;

	private uint lastJobId;

	private float minBlinkTime;

	private float isTxTime;

	private float isRxTime;

	private bool isTx;

	private bool isRx;

	private string pendingLineData;

	private float lastRetryTime;

	private List<byte> receivedData;

	private static readonly byte[] emptyByteArray;

	private static readonly LuaTableContent emptyLuaTable;

	private SerialPort serialPort;

	private const int MAX_RECEIVE_BUFFER_SIZE = 8000000;

	private bool rxException;

	private bool isActive => false;

	private uint NewJobId()
	{
		return 0u;
	}

	private uint AddJob(Job job)
	{
		return 0u;
	}

	private void ClearJobs()
	{
	}

	public override void AllocResources()
	{
	}

	public override void DeallocResources()
	{
	}

	protected override void OnSetupFinished()
	{
	}

	protected override void ExecuteCommand(int commandId)
	{
	}

	private void SetLight(int index, bool state, Color color)
	{
	}

	protected override void UpdateVisuals()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	private void UpdateLeds()
	{
	}

	public void OnTextClick()
	{
	}

	private void CloseSerialComunication()
	{
	}

	private void OpenSerialCommunication(bool failEvent = true)
	{
	}

	private void SerialPort_DataReceived(byte b)
	{
	}

	private void SerialPort_RxException(Exception e)
	{
	}

	private void SerialCommunicationThread(object obj)
	{
	}

	public override void OnTurnOff()
	{
	}

	private double Clamp(double v, double min, double max)
	{
		return 0.0;
	}

	public static List<int> GetPorts()
	{
		return null;
	}

	public IAsyncJobVoid Script_WriteInt8(double value)
	{
		return null;
	}

	public IAsyncJobVoid Script_WriteUInt8(double value)
	{
		return null;
	}

	public IAsyncJobVoid Script_WriteInt16(double value)
	{
		return null;
	}

	public IAsyncJobVoid Script_WriteUInt16(double value)
	{
		return null;
	}

	public IAsyncJobVoid Script_WriteInt32(double value)
	{
		return null;
	}

	public IAsyncJobVoid Script_WriteUInt32(double value)
	{
		return null;
	}

	public IAsyncJobVoid Script_WriteFloat32(double value)
	{
		return null;
	}

	public IAsyncJobVoid Script_WriteFloat64(double value)
	{
		return null;
	}

	public IAsyncJobVoid Script_Write(byte[] data)
	{
		return null;
	}

	public IAsyncJobVoid Script_Print(byte[] text)
	{
		return null;
	}

	public IAsyncJobVoid Script_Println(byte[] text)
	{
		return null;
	}

	public float[] Script_GetAvailablePorts()
	{
		return null;
	}
}
