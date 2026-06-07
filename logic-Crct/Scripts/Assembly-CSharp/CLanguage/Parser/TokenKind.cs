namespace CLanguage.Parser
{
	public class TokenKind
	{
		public const int COMMENT = 999;

		public const int IDENTIFIER = 257;

		public const int CONSTANT = 258;

		public const int STRING_LITERAL = 259;

		public const int SIZEOF = 260;

		public const int PTR_OP = 261;

		public const int INC_OP = 262;

		public const int DEC_OP = 263;

		public const int LEFT_OP = 264;

		public const int RIGHT_OP = 265;

		public const int LE_OP = 266;

		public const int GE_OP = 267;

		public const int EQ_OP = 268;

		public const int NE_OP = 269;

		public const int COLONCOLON = 270;

		public const int AND_OP = 271;

		public const int OR_OP = 272;

		public const int MUL_ASSIGN = 273;

		public const int DIV_ASSIGN = 274;

		public const int MOD_ASSIGN = 275;

		public const int ADD_ASSIGN = 276;

		public const int SUB_ASSIGN = 277;

		public const int LEFT_ASSIGN = 278;

		public const int RIGHT_ASSIGN = 279;

		public const int BINARY_AND_ASSIGN = 280;

		public const int BINARY_XOR_ASSIGN = 281;

		public const int BINARY_OR_ASSIGN = 282;

		public const int AND_ASSIGN = 283;

		public const int OR_ASSIGN = 284;

		public const int TYPE_NAME = 285;

		public const int PUBLIC = 286;

		public const int PRIVATE = 287;

		public const int PROTECTED = 288;

		public const int TYPEDEF = 289;

		public const int EXTERN = 290;

		public const int STATIC = 291;

		public const int AUTO = 292;

		public const int REGISTER = 293;

		public const int INLINE = 294;

		public const int RESTRICT = 295;

		public const int CHAR = 296;

		public const int SHORT = 297;

		public const int INT = 298;

		public const int LONG = 299;

		public const int SIGNED = 300;

		public const int UNSIGNED = 301;

		public const int FLOAT = 302;

		public const int DOUBLE = 303;

		public const int CONST = 304;

		public const int VOLATILE = 305;

		public const int VOID = 306;

		public const int BOOL = 307;

		public const int COMPLEX = 308;

		public const int IMAGINARY = 309;

		public const int TRUE = 310;

		public const int FALSE = 311;

		public const int STRUCT = 312;

		public const int CLASS = 313;

		public const int UNION = 314;

		public const int ENUM = 315;

		public const int ELLIPSIS = 316;

		public const int CASE = 317;

		public const int DEFAULT = 318;

		public const int IF = 319;

		public const int ELSE = 320;

		public const int SWITCH = 321;

		public const int WHILE = 322;

		public const int DO = 323;

		public const int FOR = 324;

		public const int GOTO = 325;

		public const int CONTINUE = 326;

		public const int BREAK = 327;

		public const int RETURN = 328;

		public const int EOL = 329;

		public const int yyErrorCode = 256;
	}
}
