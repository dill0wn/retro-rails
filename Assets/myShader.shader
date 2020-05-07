Shader "Tutorial/myShader" 
{
	Properties {
	    _Color ("Main Color", Color) = (1,1,1,0.5)
	    _MainTex ("Texture", 2D) = "white" { }
	}

    SubShader 
    {      
    	Pass 
    	{
			CGPROGRAM
			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction
			
			#include "UnityCG.cginc"
			
			float4 _Color;
			sampler2D _MainTex;
			
			struct vertex2Fragment 
			{
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			
			float4 _MainTex_ST;
			
			// appdata_base is builtin from UnityCG.cginc
			vertex2Fragment vertexFunction(appdata_base v)
			{
				vertex2Fragment o;
				o.position = mul (UNITY_MATRIX_MVP, v.vertex);
			    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
				return o;
			}
			
			half4 fragmentFunction (vertex2Fragment i) : COLOR
			{
			    half4 texcol = tex2D (_MainTex, i.uv);
			    return texcol * _Color;
			}
			
			ENDCG
        }
    }
    
    FallBack "VertexLit"
} 