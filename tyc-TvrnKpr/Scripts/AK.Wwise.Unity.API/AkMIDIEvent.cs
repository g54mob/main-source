using System;

public class AkMIDIEvent : IDisposable
{
	public class tGen : IDisposable
	{
		private IntPtr swigCPtr;

		protected bool swigCMemOwn;

		public byte byParam1
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte byParam2
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal tGen(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static IntPtr getCPtr(tGen obj)
		{
			return (IntPtr)0;
		}

		internal virtual void setCPtr(IntPtr cPtr)
		{
		}

		~tGen()
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public tGen()
		{
		}
	}

	public class tNoteOnOff : IDisposable
	{
		private IntPtr swigCPtr;

		protected bool swigCMemOwn;

		public byte byNote
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte byVelocity
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal tNoteOnOff(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static IntPtr getCPtr(tNoteOnOff obj)
		{
			return (IntPtr)0;
		}

		internal virtual void setCPtr(IntPtr cPtr)
		{
		}

		~tNoteOnOff()
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public tNoteOnOff()
		{
		}
	}

	public class tCc : IDisposable
	{
		private IntPtr swigCPtr;

		protected bool swigCMemOwn;

		public byte byCc
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte byValue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal tCc(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static IntPtr getCPtr(tCc obj)
		{
			return (IntPtr)0;
		}

		internal virtual void setCPtr(IntPtr cPtr)
		{
		}

		~tCc()
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public tCc()
		{
		}
	}

	public class tPitchBend : IDisposable
	{
		private IntPtr swigCPtr;

		protected bool swigCMemOwn;

		public byte byValueLsb
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte byValueMsb
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal tPitchBend(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static IntPtr getCPtr(tPitchBend obj)
		{
			return (IntPtr)0;
		}

		internal virtual void setCPtr(IntPtr cPtr)
		{
		}

		~tPitchBend()
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public tPitchBend()
		{
		}
	}

	public class tNoteAftertouch : IDisposable
	{
		private IntPtr swigCPtr;

		protected bool swigCMemOwn;

		public byte byNote
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte byValue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal tNoteAftertouch(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static IntPtr getCPtr(tNoteAftertouch obj)
		{
			return (IntPtr)0;
		}

		internal virtual void setCPtr(IntPtr cPtr)
		{
		}

		~tNoteAftertouch()
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public tNoteAftertouch()
		{
		}
	}

	public class tChanAftertouch : IDisposable
	{
		private IntPtr swigCPtr;

		protected bool swigCMemOwn;

		public byte byValue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal tChanAftertouch(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static IntPtr getCPtr(tChanAftertouch obj)
		{
			return (IntPtr)0;
		}

		internal virtual void setCPtr(IntPtr cPtr)
		{
		}

		~tChanAftertouch()
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public tChanAftertouch()
		{
		}
	}

	public class tProgramChange : IDisposable
	{
		private IntPtr swigCPtr;

		protected bool swigCMemOwn;

		public byte byProgramNum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal tProgramChange(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static IntPtr getCPtr(tProgramChange obj)
		{
			return (IntPtr)0;
		}

		internal virtual void setCPtr(IntPtr cPtr)
		{
		}

		~tProgramChange()
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public tProgramChange()
		{
		}
	}

	public class tWwiseCmd : IDisposable
	{
		private IntPtr swigCPtr;

		protected bool swigCMemOwn;

		public ushort uCmd
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public uint uArg
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		internal tWwiseCmd(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static IntPtr getCPtr(tWwiseCmd obj)
		{
			return (IntPtr)0;
		}

		internal virtual void setCPtr(IntPtr cPtr)
		{
		}

		~tWwiseCmd()
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public tWwiseCmd()
		{
		}
	}

	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public byte byChan
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public tGen Gen
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public tCc Cc
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public tNoteOnOff NoteOnOff
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public tPitchBend PitchBend
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public tNoteAftertouch NoteAftertouch
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public tChanAftertouch ChanAftertouch
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public tProgramChange ProgramChange
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public tWwiseCmd WwiseCmd
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkMIDIEventTypes byType
	{
		get
		{
			return default(AkMIDIEventTypes);
		}
		set
		{
		}
	}

	public byte byOnOffNote
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public byte byVelocity
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public AkMIDICcTypes byCc
	{
		get
		{
			return default(AkMIDICcTypes);
		}
		set
		{
		}
	}

	public byte byCcValue
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public byte byValueLsb
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public byte byValueMsb
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public byte byAftertouchNote
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public byte byNoteAftertouchValue
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public byte byChanAftertouchValue
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public byte byProgramNum
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public ushort uCmd
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public uint uArg
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal AkMIDIEvent(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkMIDIEvent obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkMIDIEvent()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkMIDIEvent()
	{
	}
}
