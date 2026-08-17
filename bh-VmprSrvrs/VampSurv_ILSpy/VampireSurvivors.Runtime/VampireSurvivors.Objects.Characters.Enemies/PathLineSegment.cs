using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Objects.Characters.Enemies;

public struct PathLineSegment : IEquatable<PathLineSegment>
{
	private readonly Vector2 _003CStart_003Ek__BackingField;

	private readonly Vector2 _003CEnd_003Ek__BackingField;

	private readonly float _003CLength_003Ek__BackingField;

	public Vector2 Start => _003CStart_003Ek__BackingField;

	public Vector2 End
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
	}

	public float Length => _003CLength_003Ek__BackingField;

	public PathLineSegment(Vector2 start, Vector2 end)
	{
		_003CEnd_003Ek__BackingField = end;
		_003CStart_003Ek__BackingField = start;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
		float num = default(float);
		_003CLength_003Ek__BackingField = num;
	}

	public bool Equals(PathLineSegment other)
	{
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018778B4B8h\"");
		if ((object)_003CStart_003Ek__BackingField == (object)other._003CStart_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018778B4B8h\"");
			object obj = default(object);
			object obj2 = default(object);
			if (obj == obj2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018778B4B8h\"");
				if ((object)_003CEnd_003Ek__BackingField == (object)other._003CEnd_003Ek__BackingField)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018778B4B8h\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.PathLineSegment)+C]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [other @ rdx (VampireSurvivors.Objects.Characters.Enemies.PathLineSegment)+C]");
					if (num == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018778B498h\"");
						if (other._003CLength_003Ek__BackingField == _003CLength_003Ek__BackingField)
						{
							return true;
						}
						object obj3 = other._003CLength_003Ek__BackingField & -2147483649L;
						if ((nint)obj3 > 2139095040)
						{
							object obj4 = _003CLength_003Ek__BackingField & -2147483649L;
							bool flag = (nint)obj4 < 2139095040;
							object obj5 = obj4 - 2139095040;
							bool flag2 = obj5 == null;
							bool flag3 = !flag;
							bool flag4 = !flag2;
							return flag4 & flag3;
						}
					}
				}
			}
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		//IL_0013: Expected I, but got O
		//IL_0057: Expected I, but got O
		//IL_022d: Expected I4, but got O
		//IL_015a: Invalid comparison between I and F4
		//IL_0191: Expected O, but got I8
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		if (obj != null)
		{
			nint num = (nint)typeof(PathLineSegment);
			bool flag = (object)obj.GetType() != typeof(PathLineSegment);
			object obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if (obj2 != null)
			{
				nint num2 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v3 (Il2CppClass<System.Object>)+40]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.PathLineSegment>)+40]");
				if (num3 != 0)
				{
					InvalidCastException ex = new InvalidCastException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018778B5BCh\"");
				Vector2 vector = _003CStart_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rdx (System.Object)+10]");
				if ((object)vector == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018778B5BCh\"");
					object obj3 = default(object);
					object obj4 = default(object);
					if (obj3 == obj4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018778B5BCh\"");
						if ((object)_003CEnd_003Ek__BackingField == obj4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018778B5BCh\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.PathLineSegment)+C]");
							if (0 == (nint)obj4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018778B592h\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rdx (System.Object)+20]");
								if (0f == _003CLength_003Ek__BackingField)
								{
									return true;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ rdx (System.Object)+20]");
								object obj5 = 0 & -2147483649L;
								if ((nint)obj5 > 2139095040)
								{
									object obj6 = _003CLength_003Ek__BackingField & -2147483649L;
									bool flag2 = (nint)obj6 < 2139095040;
									object obj7 = obj6 - 2139095040;
									bool flag3 = obj7 == null;
									bool flag4 = !flag2;
									bool flag5 = !flag3;
									return flag5 & flag4;
								}
							}
						}
					}
				}
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		Vector2 value = default(Vector2);
		return HashCode.Combine(_003CStart_003Ek__BackingField, value, _003CLength_003Ek__BackingField);
	}
}
