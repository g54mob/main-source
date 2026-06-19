using System.Runtime.CompilerServices;

namespace MessagePack.Internal
{
	public static class FarmHash
	{
		private struct pair
		{
			public ulong first;

			public ulong second;

			public pair(ulong first, ulong second)
			{
				this.first = first;
				this.second = second;
			}
		}

		private const uint c1 = 3432918353u;

		private const uint c2 = 461845907u;

		private const ulong k0 = 14097894508562428199uL;

		private const ulong k1 = 13011662864482103923uL;

		private const ulong k2 = 11160318154034397263uL;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static uint Hash32(byte[] bytes, int offset, int count)
		{
			if (count <= 4)
			{
				return Hash32Len0to4(bytes, offset, (uint)count);
			}
			fixed (byte* s = &bytes[offset])
			{
				return Hash32(s, (uint)count);
			}
		}

		private unsafe static uint Fetch32(byte* p)
		{
			return *(uint*)p;
		}

		private static uint Rotate32(uint val, int shift)
		{
			if (shift != 0)
			{
				return (val >> shift) | (val << 32 - shift);
			}
			return val;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint fmix(uint h)
		{
			h ^= h >> 16;
			h *= 2246822507u;
			h ^= h >> 13;
			h *= 3266489909u;
			h ^= h >> 16;
			return h;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint Mur(uint a, uint h)
		{
			a *= 3432918353u;
			a = Rotate32(a, 17);
			a *= 461845907;
			h ^= a;
			h = Rotate32(h, 19);
			return h * 5 + 3864292196u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static uint Hash32Len0to4(byte[] s, int offset, uint len)
		{
			uint num = 0u;
			uint num2 = 9u;
			long num3 = offset + len;
			for (int i = offset; i < num3; i++)
			{
				num = (uint)((int)num * -862048943 + s[i]);
				num2 ^= num;
			}
			return fmix(Mur(num, Mur(len, num2)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static uint Hash32Len5to12(byte* s, uint len)
		{
			uint num = len;
			uint num2 = len * 5;
			uint h = num2;
			return fmix(Mur(h: Mur(h: Mur(num + Fetch32(s), h), a: num2 + Fetch32(s + len - 4)), a: 9 + Fetch32(s + ((len >> 1) & 4))));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static uint Hash32Len13to24(byte* s, uint len)
		{
			uint val = Fetch32(s - 4 + (len >> 1));
			uint a = Fetch32(s + 4);
			uint num = Fetch32(s + len - 8);
			uint num2 = Fetch32(s + (len >> 1));
			uint a2 = Fetch32(s);
			uint num3 = Fetch32(s + len - 4);
			uint h = (uint)((int)num2 * -862048943) + len;
			val = Rotate32(val, 12) + num3;
			h = Mur(num, h) + val;
			val = Rotate32(val, 3) + num;
			h = Mur(a2, h) + val;
			val = Rotate32(val + num3, 12) + num2;
			h = Mur(a, h) + val;
			return fmix(h);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static uint Hash32(byte* s, uint len)
		{
			switch (len)
			{
			case 13u:
			case 14u:
			case 15u:
			case 16u:
			case 17u:
			case 18u:
			case 19u:
			case 20u:
			case 21u:
			case 22u:
			case 23u:
			case 24u:
				return Hash32Len13to24(s, len);
			case 0u:
			case 1u:
			case 2u:
			case 3u:
			case 4u:
			case 5u:
			case 6u:
			case 7u:
			case 8u:
			case 9u:
			case 10u:
			case 11u:
			case 12u:
				return Hash32Len5to12(s, len);
			default:
			{
				uint num = len;
				uint num2 = 3432918353u * len;
				uint num3 = num2;
				uint num4 = Rotate32(Fetch32(s + len - 4) * 3432918353u, 17) * 461845907;
				uint num5 = Rotate32(Fetch32(s + len - 8) * 3432918353u, 17) * 461845907;
				uint num6 = Rotate32(Fetch32(s + len - 16) * 3432918353u, 17) * 461845907;
				uint num7 = Rotate32(Fetch32(s + len - 12) * 3432918353u, 17) * 461845907;
				uint num8 = Rotate32(Fetch32(s + len - 20) * 3432918353u, 17) * 461845907;
				num ^= num4;
				num = Rotate32(num, 19);
				num = num * 5 + 3864292196u;
				num ^= num6;
				num = Rotate32(num, 19);
				num = num * 5 + 3864292196u;
				num2 ^= num5;
				num2 = Rotate32(num2, 19);
				num2 = num2 * 5 + 3864292196u;
				num2 ^= num7;
				num2 = Rotate32(num2, 19);
				num2 = num2 * 5 + 3864292196u;
				num3 += num8;
				num3 = Rotate32(num3, 19) + 113;
				uint num9 = (len - 1) / 20;
				do
				{
					uint num10 = Fetch32(s);
					uint num11 = Fetch32(s + 4);
					uint num12 = Fetch32(s + 8);
					uint num13 = Fetch32(s + 12);
					uint num14 = Fetch32(s + 16);
					num += num10;
					num2 += num11;
					num3 += num12;
					num = Mur(num13, num) + num14;
					num2 = Mur(num12, num2) + num10;
					num3 = Mur(num11 + (uint)((int)num14 * -862048943), num3) + num13;
					num3 += num2;
					num2 += num3;
					s += 20;
				}
				while (--num9 != 0);
				num2 = Rotate32(num2, 11) * 3432918353u;
				num2 = Rotate32(num2, 17) * 3432918353u;
				num3 = Rotate32(num3, 11) * 3432918353u;
				num3 = Rotate32(num3, 17) * 3432918353u;
				num = Rotate32(num + num2, 19);
				num = num * 5 + 3864292196u;
				num = Rotate32(num, 17) * 3432918353u;
				num = Rotate32(num + num3, 19);
				num = num * 5 + 3864292196u;
				return Rotate32(num, 17) * 3432918353u;
			}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static ulong Hash64(byte[] bytes, int offset, int count)
		{
			fixed (byte* s = &bytes[offset])
			{
				return Hash64(s, (uint)count);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static pair make_pair(ulong first, ulong second)
		{
			return new pair(first, second);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void swap(ref ulong x, ref ulong z)
		{
			ulong num = z;
			z = x;
			x = num;
		}

		private unsafe static ulong Fetch64(byte* p)
		{
			return *(ulong*)p;
		}

		private static ulong Rotate64(ulong val, int shift)
		{
			if (shift != 0)
			{
				return (val >> shift) | (val << 64 - shift);
			}
			return val;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong ShiftMix(ulong val)
		{
			return val ^ (val >> 47);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong HashLen16(ulong u, ulong v, ulong mul)
		{
			ulong num = (u ^ v) * mul;
			num ^= num >> 47;
			ulong num2 = (v ^ num) * mul;
			return (num2 ^ (num2 >> 47)) * mul;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong Hash64(byte* s, uint len)
		{
			if (len <= 16)
			{
				return HashLen0to16(s, len);
			}
			if (len <= 32)
			{
				return HashLen17to32(s, len);
			}
			if (len <= 64)
			{
				return HashLen33to64(s, len);
			}
			if (len <= 96)
			{
				return HashLen65to96(s, len);
			}
			if (len <= 256)
			{
				return Hash64NA(s, len);
			}
			return Hash64UO(s, len);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong HashLen0to16(byte* s, uint len)
		{
			switch (len)
			{
			default:
			{
				ulong num7 = (ulong)(-7286425919675154353L + len * 2);
				ulong num8 = Fetch64(s) + 11160318154034397263uL;
				ulong num9 = Fetch64(s + len - 8);
				ulong u = Rotate64(num9, 37) * num7 + num8;
				ulong v = (Rotate64(num8, 25) + num9) * num7;
				return HashLen16(u, v, num7);
			}
			case 4u:
			case 5u:
			case 6u:
			case 7u:
			{
				ulong mul = (ulong)(-7286425919675154353L + len * 2);
				ulong num6 = Fetch32(s);
				return HashLen16(len + (num6 << 3), Fetch32(s + len - 4), mul);
			}
			case 1u:
			case 2u:
			case 3u:
			{
				byte num = *s;
				ushort num2 = s[len >> 1];
				ushort num3 = s[len - 1];
				int num4 = num + (num2 << 8);
				uint num5 = len + (uint)(num3 << 2);
				return ShiftMix((ulong)(((uint)num4 * -7286425919675154353L) ^ (num5 * -4348849565147123417L))) * 11160318154034397263uL;
			}
			case 0u:
				return 11160318154034397263uL;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong HashLen17to32(byte* s, uint len)
		{
			ulong num = (ulong)(-7286425919675154353L + len * 2);
			ulong num2 = Fetch64(s) * 13011662864482103923uL;
			ulong num3 = Fetch64(s + 8);
			ulong num4 = Fetch64(s + len - 8) * num;
			ulong num5 = Fetch64(s + len - 16) * 11160318154034397263uL;
			return HashLen16(Rotate64(num2 + num3, 43) + Rotate64(num4, 30) + num5, num2 + Rotate64(num3 + 11160318154034397263uL, 18) + num4, num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong H32(byte* s, uint len, ulong mul, ulong seed0 = 0uL, ulong seed1 = 0uL)
		{
			ulong num = Fetch64(s) * 13011662864482103923uL;
			ulong num2 = Fetch64(s + 8);
			ulong num3 = Fetch64(s + len - 8) * mul;
			ulong num4 = Fetch64(s + len - 16) * 11160318154034397263uL;
			ulong num5 = Rotate64(num + num2, 43) + Rotate64(num3, 30) + num4 + seed0;
			ulong num6 = num + Rotate64(num2 + 11160318154034397263uL, 18) + num3 + seed1;
			num = ShiftMix((num5 ^ num6) * mul);
			return ShiftMix((num6 ^ num) * mul);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong HashLen33to64(byte* s, uint len)
		{
			ulong num = (ulong)(-7286425919675154383L + 2 * len);
			ulong num2 = H32(s, 32u, 11160318154034397233uL, 0uL, 0uL);
			return (H32(s + len - 32, 32u, num, 0uL, 0uL) * num + num2) * num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong HashLen65to96(byte* s, uint len)
		{
			ulong num = (ulong)(-7286425919675154467L + 2 * len);
			ulong num2 = H32(s, 32u, 11160318154034397149uL, 0uL, 0uL);
			ulong num3 = H32(s + 32, 32u, num, 0uL, 0uL);
			return (H32(s + len - 32, 32u, num, num2, num3) * 9 + (num2 >> 17) + (num3 >> 21)) * num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static pair WeakHashLen32WithSeeds(ulong w, ulong x, ulong y, ulong z, ulong a, ulong b)
		{
			a += w;
			b = Rotate64(b + a + z, 21);
			ulong num = a;
			a += x;
			a += y;
			b += Rotate64(a, 44);
			return make_pair(a + z, b + num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static pair WeakHashLen32WithSeeds(byte* s, ulong a, ulong b)
		{
			return WeakHashLen32WithSeeds(Fetch64(s), Fetch64(s + 8), Fetch64(s + 16), Fetch64(s + 24), a, b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong Hash64NA(byte* s, uint len)
		{
			ulong num = 81uL;
			ulong num2 = 2480279821605975764uL;
			ulong x = ShiftMix((ulong)((long)num2 * -7286425919675154353L + 113)) * 11160318154034397263uL;
			pair pair2 = make_pair(0uL, 0uL);
			pair pair3 = make_pair(0uL, 0uL);
			num = (ulong)((long)num * -7286425919675154353L) + Fetch64(s);
			byte* ptr = s + (len - 1) / 64 * 64;
			byte* ptr2 = ptr + ((len - 1) & 0x3F) - 63;
			do
			{
				num = Rotate64(num + num2 + pair2.first + Fetch64(s + 8), 37) * 13011662864482103923uL;
				num2 = Rotate64(num2 + pair2.second + Fetch64(s + 48), 42) * 13011662864482103923uL;
				num ^= pair3.second;
				num2 += pair2.first + Fetch64(s + 40);
				x = Rotate64(x + pair3.first, 33) * 13011662864482103923uL;
				pair2 = WeakHashLen32WithSeeds(s, pair2.second * 13011662864482103923uL, num + pair3.first);
				pair3 = WeakHashLen32WithSeeds(s + 32, x + pair3.second, num2 + Fetch64(s + 16));
				swap(ref x, ref num);
				s += 64;
			}
			while (s != ptr);
			ulong num3 = 13011662864482103923uL + ((x & 0xFF) << 1);
			s = ptr2;
			pair3.first += (len - 1) & 0x3F;
			pair2.first += pair3.first;
			pair3.first += pair2.first;
			num = Rotate64(num + num2 + pair2.first + Fetch64(s + 8), 37) * num3;
			num2 = Rotate64(num2 + pair2.second + Fetch64(s + 48), 42) * num3;
			num ^= pair3.second * 9;
			num2 += pair2.first * 9 + Fetch64(s + 40);
			x = Rotate64(x + pair3.first, 33) * num3;
			pair2 = WeakHashLen32WithSeeds(s, pair2.second * num3, num + pair3.first);
			pair3 = WeakHashLen32WithSeeds(s + 32, x + pair3.second, num2 + Fetch64(s + 16));
			swap(ref x, ref num);
			return HashLen16((ulong)((long)HashLen16(pair2.first, pair3.first, num3) + (long)ShiftMix(num2) * -4348849565147123417L) + x, HashLen16(pair2.second, pair3.second, num3) + num, num3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ulong H(ulong x, ulong y, ulong mul, int r)
		{
			ulong num = (x ^ y) * mul;
			num ^= num >> 47;
			return Rotate64((y ^ num) * mul, r) * mul;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong Hash64UO(byte* s, uint len)
		{
			ulong num = 81uL;
			ulong num2 = 113uL;
			ulong z = ShiftMix(num2 * 11160318154034397263uL) * 11160318154034397263uL;
			pair pair2 = make_pair(81uL, 0uL);
			pair pair3 = make_pair(0uL, 0uL);
			ulong x = num - z;
			num *= 11160318154034397263uL;
			ulong num3 = 11160318154034397263uL + (x & 0x82);
			byte* ptr = s + (len - 1) / 64 * 64;
			byte* ptr2 = ptr + ((len - 1) & 0x3F) - 63;
			do
			{
				ulong num4 = Fetch64(s);
				ulong num5 = Fetch64(s + 8);
				ulong num6 = Fetch64(s + 16);
				ulong num7 = Fetch64(s + 24);
				ulong num8 = Fetch64(s + 32);
				ulong num9 = Fetch64(s + 40);
				ulong num10 = Fetch64(s + 48);
				ulong num11 = Fetch64(s + 56);
				num += num4 + num5;
				num2 += num6;
				z += num7;
				pair2.first += num8;
				pair2.second += num9 + num5;
				pair3.first += num10;
				pair3.second += num11;
				num = Rotate64(num, 26);
				num *= 9;
				num2 = Rotate64(num2, 29);
				z *= num3;
				pair2.first = Rotate64(pair2.first, 33);
				pair2.second = Rotate64(pair2.second, 30);
				pair3.first ^= num;
				pair3.first *= 9uL;
				z = Rotate64(z, 32);
				z += pair3.second;
				pair3.second += z;
				z *= 9;
				swap(ref x, ref num2);
				z += num4 + num10;
				pair2.first += num6;
				pair2.second += num7;
				pair3.first += num8;
				pair3.second += num9 + num10;
				num += num5;
				num2 += num11;
				num2 += pair2.first;
				pair2.first += num - num2;
				pair2.second += pair3.first;
				pair3.first += pair2.second;
				pair3.second += num - num2;
				num += pair3.second;
				pair3.second = Rotate64(pair3.second, 34);
				swap(ref x, ref z);
				s += 64;
			}
			while (s != ptr);
			s = ptr2;
			x *= 9;
			pair2.second = Rotate64(pair2.second, 28);
			pair2.first = Rotate64(pair2.first, 20);
			pair3.first += (len - 1) & 0x3F;
			x += num2;
			num2 += x;
			num = Rotate64(num2 - num + pair2.first + Fetch64(s + 8), 37) * num3;
			num2 = Rotate64(num2 ^ pair2.second ^ Fetch64(s + 48), 42) * num3;
			num ^= pair3.second * 9;
			num2 += pair2.first + Fetch64(s + 40);
			z = Rotate64(z + pair3.first, 33) * num3;
			pair2 = WeakHashLen32WithSeeds(s, pair2.second * num3, num + pair3.first);
			pair3 = WeakHashLen32WithSeeds(s + 32, z + pair3.second, num2 + Fetch64(s + 16));
			return H(HashLen16(pair2.first + num, pair3.first ^ num2, num3) + z - x, H(pair2.second + num2, pair3.second + z, 11160318154034397263uL, 30) ^ num, 11160318154034397263uL, 31);
		}
	}
}
