internal class jcXazxtpglhNkCEyvOXbwbgAELMb : TrPtHvDNhUzaBqlyMmTMOEWQxyO
{
	public override wQJNyUaUvslgkGHqqbQGKnHjBYM DeviceType
	{
		get
		{
			return wQJNyUaUvslgkGHqqbQGKnHjBYM.OjRdrXVzVQaGEGzhFLzNjhrLLBZ;
		}
	}

	public jcXazxtpglhNkCEyvOXbwbgAELMb(JAfkxdvdQnyFyALnVRHRXQkPlEy nativeGameController, qNsaluFiUoLEvSsAIYUscPCZLjmQ joystickInfo)
		: base(nativeGameController, joystickInfo, gNEAicDxLHkrFZgYqIFdMmtDmHv.OjRdrXVzVQaGEGzhFLzNjhrLLBZ, 15, 6, 0, 0)
	{
	}

	public override bool IsAttached()
	{
		if (yhrAgHUqtIQjKILOnedYwvFWjYQ != null)
		{
			while (true)
			{
				int num = -2107023602;
				while (true)
				{
					switch (num ^ -2107023601)
					{
					case 2:
						break;
					case 1:
						goto IL_0026;
					default:
						goto end_IL_0008;
					}
					break;
					IL_0026:
					if (!yhrAgHUqtIQjKILOnedYwvFWjYQ.IsValid)
					{
						num = -2107023601;
						continue;
					}
					return ghVaXMJBYQVankSHALdOAwQaFIx.cQXTyfgHDlBNWtYqKqBJIXbXHbK(yhrAgHUqtIQjKILOnedYwvFWjYQ);
				}
				continue;
				end_IL_0008:
				break;
			}
		}
		return false;
	}

	protected override void InitializeHaptic()
	{
		if (!base.IsValid)
		{
			goto IL_0008;
		}
		goto IL_0032;
		IL_0008:
		int num = 1145462000;
		goto IL_000d;
		IL_000d:
		switch (num ^ 0x44465CF1)
		{
		case 3:
			break;
		default:
			return;
		case 1:
			return;
		case 0:
			goto IL_0032;
		case 2:
			return;
		}
		goto IL_0008;
		IL_0032:
		rrGXmcfcGpJYAsSkHwJrDWDYMxo(new YlWFkSrNjhWjdvjHemdfYAMOisT(ghVaXMJBYQVankSHALdOAwQaFIx.ogEZUGzhUNPUZgnEuRJZTqOurxf(yhrAgHUqtIQjKILOnedYwvFWjYQ)));
		num = 1145462003;
		goto IL_000d;
	}

	protected override void CloseDevice()
	{
		if (yhrAgHUqtIQjKILOnedYwvFWjYQ == null)
		{
			return;
		}
		if (!yhrAgHUqtIQjKILOnedYwvFWjYQ.IsValid)
		{
			while (true)
			{
				switch (0x7D9BC8B9 ^ 0x7D9BC8B8)
				{
				case 3:
					break;
				case 1:
					return;
				case 0:
					goto end_IL_0015;
				default:
					goto IL_005a;
				}
				continue;
				end_IL_0015:
				break;
			}
		}
		if (!IsAttached())
		{
			yhrAgHUqtIQjKILOnedYwvFWjYQ.Clear();
			return;
		}
		goto IL_005a;
		IL_005a:
		ghVaXMJBYQVankSHALdOAwQaFIx.icRvXyukGFCbzpwamidULnfXqZX(yhrAgHUqtIQjKILOnedYwvFWjYQ);
		yhrAgHUqtIQjKILOnedYwvFWjYQ.Clear();
	}
}
