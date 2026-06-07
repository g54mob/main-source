using ModApi.Common.Attributes;

namespace ModApi.Planet.Modifiers.VertexData
{
	public enum BasicArithmeticType
	{
		[DisplayName("A + B")]
		Add_A_PLUS_B = 0,
		[DisplayName("A + C")]
		Add_A_PLUS_C = 1,
		[DisplayName("A - B")]
		Subtract_A_MINUS_B = 2,
		[DisplayName("A - C")]
		Subtract_A_MINUS_C = 3,
		[DisplayName("C - A")]
		Subtract_C_MINUS_A = 4,
		[DisplayName("A * B")]
		Multiply_A_TIMES_B = 5,
		[DisplayName("A * C")]
		Multiply_A_TIMES_C = 6,
		[DisplayName("A / B")]
		Divide_A_By_B = 7,
		[DisplayName("A / C")]
		Divide_A_By_C = 8,
		[DisplayName("C / A")]
		Divide_C_By_A = 9,
		[DisplayName("A^B")]
		Exponent_A_POW_B = 10,
		[DisplayName("A^C")]
		Exponent_A_POW_C = 11,
		[DisplayName("C^A")]
		Exponent_C_POW_A = 12,
		[DisplayName("Absolute Value of A")]
		AbsoluteValue_A = 13,
		[DisplayName("Minimum of A and B")]
		Min_AB = 14,
		[DisplayName("Minimum of A and C")]
		Min_AC = 15,
		[DisplayName("Maximum of A and B")]
		Max_AB = 16,
		[DisplayName("Maximum of A and C")]
		Max_AC = 17,
		[DisplayName("Sign of A (-1 or 1)")]
		Sign_A = 18
	}
}
