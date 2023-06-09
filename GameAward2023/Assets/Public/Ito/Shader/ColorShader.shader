Shader "Custom/ColorShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_ColorFlag("ColorFlag", Range(0,1)) = 0.0
		_CraftFlag("CraftFlag", Range(0,1)) = 0.0
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0		

		//
		#pragma multi_compile _ENABLE_FLAG

		sampler2D _MainTex;


		struct Input
		{
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		bool _ColorFlag;
		bool _CraftFlag;


		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)



		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;

			#if defined(_ENABLE_FLAG)
			if (_ColorFlag)
			{
				if (_CraftFlag)
				{
					// 青色
					o.Albedo.rgb *= fixed3(0.2, 0.2, 0.85);
				}
				else
				{
					// 赤色
					o.Albedo.rgb *= fixed3(0.85, 0.2, 0.2);
				}
			}
			//else
			//{
			//	// 白色
			//	o.Albedo.rgb += fixed3(1, 1, 1);
			//}
			#endif
		}
		ENDCG
	}
		FallBack "Diffuse"
}
