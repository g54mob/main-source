using System;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Saves;

public class SaveSummary
{
	private PlayerOptionsData _003CPod_003Ek__BackingField;

	private byte[] _003CData_003Ek__BackingField;

	private string _timestamp;

	private DateTime _003CRawDateTime_003Ek__BackingField;

	private int _003C_totalGold_003Ek__BackingField;

	private CharacterType _003C_selectedCharacter_003Ek__BackingField;

	private StageType _003C_selectedStage_003Ek__BackingField;

	private int _003C_unlockedCharacters_003Ek__BackingField;

	private int _003C_achievements_003Ek__BackingField;

	public PlayerOptionsData Pod
	{
		get
		{
			return _003CPod_003Ek__BackingField;
		}
		set
		{
			_003CPod_003Ek__BackingField = value;
		}
	}

	public byte[] Data
	{
		get
		{
			return _003CData_003Ek__BackingField;
		}
		set
		{
			_003CData_003Ek__BackingField = value;
		}
	}

	public unsafe string Timestamp
	{
		get
		{
			return _timestamp;
		}
		set
		{
			//IL_0170: Expected O, but got I8
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected Ref, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected Ref, but got Unknown
			//IL_00a6: Expected I8, but got I4
			string text = "";
			if ((object)value != "")
			{
				if ("" != null && value._stringLength == text._stringLength)
				{
					ref byte first = ref *(byte*)(value + 20);
					ref byte second = ref *(byte*)("" + 20);
					ulong length = (ulong)(value._stringLength + value._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref second, length))
					{
						goto IL_0152;
					}
				}
				long num = long.Parse(value);
				DateTime dateTime = DateTime.UnixEpoch + (TimeSpan)num;
				_003CRawDateTime_003Ek__BackingField = dateTime;
				DateTime dateTime3 = default(DateTime);
				DateTime dateTime2 = dateTime3.ToLocalTime(false);
				string text2 = System.DateTimeFormat.Format(dateTime2, "d", (IFormatProvider)null);
				string text3 = System.DateTimeFormat.Format(dateTime2, "t", (IFormatProvider)null);
				string timestamp = text2 + " - " + text3;
				_timestamp = timestamp;
				return;
			}
			goto IL_0152;
			IL_0152:
			_timestamp = "";
		}
	}

	public DateTime RawDateTime
	{
		get
		{
			return _003CRawDateTime_003Ek__BackingField;
		}
		private set
		{
			_003CRawDateTime_003Ek__BackingField = value;
		}
	}

	public int _totalGold
	{
		get
		{
			return _003C_totalGold_003Ek__BackingField;
		}
		set
		{
			_003C_totalGold_003Ek__BackingField = value;
		}
	}

	public CharacterType _selectedCharacter
	{
		get
		{
			return _003C_selectedCharacter_003Ek__BackingField;
		}
		set
		{
			_003C_selectedCharacter_003Ek__BackingField = value;
		}
	}

	public StageType _selectedStage
	{
		get
		{
			return _003C_selectedStage_003Ek__BackingField;
		}
		set
		{
			_003C_selectedStage_003Ek__BackingField = value;
		}
	}

	public int _unlockedCharacters
	{
		get
		{
			return _003C_unlockedCharacters_003Ek__BackingField;
		}
		set
		{
			_003C_unlockedCharacters_003Ek__BackingField = value;
		}
	}

	public int _achievements
	{
		get
		{
			return _003C_achievements_003Ek__BackingField;
		}
		set
		{
			_003C_achievements_003Ek__BackingField = value;
		}
	}
}
