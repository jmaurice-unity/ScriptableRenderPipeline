// UNITY_SHADER_NO_UPGRADE
#ifndef UNITY_GRAPHFUNCTIONS_INCLUDED
#define UNITY_GRAPHFUNCTIONS_INCLUDED

// ----------------------------------------------------------------------------
// Included in generated graph shaders
// ----------------------------------------------------------------------------

bool IsGammaSpace()
{
    #ifdef UNITY_COLORSPACE_GAMMA
        return true;
    #else
        return false;
    #endif
}

float4 ComputeScreenPos (float4 pos, float projectionSign)
{
  float4 o = pos * 0.5f;
  o.xy = float2(o.x, o.y * projectionSign) + o.w;
  o.zw = pos.zw;
  return o;
}

struct Gradient
{
    int type;
    int colorsLength;
    int alphasLength;
    float4 colors[8];
    float2 alphas[8];
};

#ifndef SHADERGRAPH_SAMPLE_SCENE_DEPTH
    #define SHADERGRAPH_SAMPLE_SCENE_DEPTH(uv) shadergraph_SampleSceneDepth(uv)
#endif

#ifndef SHADERGRAPH_SAMPLE_SCENE_COLOR
    #define SHADERGRAPH_SAMPLE_SCENE_COLOR(uv) shadergraph_SampleSceneColor(uv)
#endif

#ifndef SHADERGRAPH_BAKED_GI
    #define SHADERGRAPH_BAKED_GI(positionWS, normalWS, uvStaticLightmap, uvDynamicLightmap) shadergraph_BakedGI(positionWS, normalWS, uvStaticLightmap, uvDynamicLightmap)
#endif

#ifndef SHADERGRAPH_REFLECTION_PROBE
    #define SHADERGRAPH_REFLECTION_PROBE(viewDir, normalOS, lod) shadergraph_ReflectionProbe(viewDir, normalOS, lod)
#endif

#ifndef SHADERGRAPH_AMBIENT_SKY
    #define SHADERGRAPH_AMBIENT_SKY float3(0,0,0)
#endif

#ifndef SHADERGRAPH_AMBIENT_EQUATOR
    #define SHADERGRAPH_AMBIENT_EQUATOR float3(0,0,0)
#endif

#ifndef SHADERGRAPH_AMBIENT_GROUND
    #define SHADERGRAPH_AMBIENT_GROUND float3(0,0,0)
#endif

float shadergraph_SampleSceneDepth(float2 uv)
{
    return 1;
}

float3 shadergraph_SampleSceneColor(float2 uv)
{
    return 0;
}

float3 shadergraph_BakedGI(float3 positionWS, float3 normalWS, float2 uvStaticLightmap, float2 uvDynamicLightmap)
{
    return 0;
}

float3 shadergraph_ReflectionProbe(float3 viewDir, float3 normalOS, float lod)
{
    return 0;
}

#endif // UNITY_GRAPHFUNCTIONS_INCLUDED
