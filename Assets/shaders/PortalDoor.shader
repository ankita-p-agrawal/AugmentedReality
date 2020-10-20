Shader "Portal/PortalDoor"
{
    Properties
    {
        
    }
    SubShader
    {
        ColorMask 0
        ZWrite off
        Cull off
        Stencil{
            Ref 1
            Pass replace
        }

        Pass
        {
            
        }
    }
}
