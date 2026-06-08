namespace LaundryBear.PlatformServices
{
	public enum Region : uint
	{
		None = 0u,
		en_us = 1u,
		en_ca = 2u,
		en_gb = 4u,
		en_au = 8u,
		en = 15u,
		fr = 32u,
		fr_ca = 64u,
		it = 128u,
		de = 256u,
		es = 512u,
		es_mx = 1024u,
		pt = 2048u,
		pt_br = 4096u,
		ru = 8192u,
		nl = 16384u,
		ja = 32768u,
		ko = 65536u,
		zh_cn = 131072u,
		zh_hans = 131072u,
		zh_tw = 262144u,
		zh_hant = 262144u,
		zh = 393216u,
		All = uint.MaxValue
	}
}
