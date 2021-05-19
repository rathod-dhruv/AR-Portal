Shader "Custom/PortalWindow"
{
    
    SubShader
    {
        //As we wanted to write on ZBuffer by defaukt if there is a object on ZBuffer it will not render but we want to render it
        ZWrite off
        ColorMask 0 //To make it Transparant
        Cull off

        Stencil
        {   
            // It will compare everything with one-> Stencil setup
            Ref 1
            Pass replace
        }

        Pass
        {
        
        }
    }
}
