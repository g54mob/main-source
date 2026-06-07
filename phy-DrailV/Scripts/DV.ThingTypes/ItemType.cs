using System;

[Flags]
public enum ItemType
{
	None = 0,
	TinyItem = 1,
	SmallItem = 2,
	MediumItem = 4,
	LargeItem = 8,
	HugeItem = 0x10,
	Paper = 0x20,
	SmallContainer = 0x40,
	MediumContainer = 0x80,
	LargeContainer = 0x100,
	PaperContainer = 0x200
}
