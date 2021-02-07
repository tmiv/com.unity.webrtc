# Generated Makefile -- DO NOT EDIT!

HOST=win64
SPEC=debug_lumin_clang-3.8_aarch64
WebRTCPlugin_BASE=D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin
WebRTCPlugin_OUTPUT=$(WebRTCPlugin_BASE)/.out/$(SPEC)


# this turns off the suffix rules built into make
.SUFFIXES:

# this turns off the RCS / SCCS implicit rules of GNU Make
% : RCS/%,v
% : RCS/%
% : %,v
% : s.%
% : SCCS/s.%

# If a rule fails, delete $@.
.DELETE_ON_ERROR:

ifeq ($(VERBOSE),)
ECHO=@
else
ECHO=
endif

ifeq ($(QUIET),)
INFO=@echo
else
INFO=@:
endif

ifeq ($(VERBOSE),)
SPAM=@: \#
else
SPAM=@echo
endif

all : prebuild build postbuild

prebuild :: 

postbuild :: 

clean :: WebRTCPlugin-clean

$(MLSDK)/tools/mabu/data/options/optimize/off.option : 

$(MLSDK)/tools/mabu/data/options/magicleap.option : 

$(MLSDK)/.metadata/components/poco_foundation.comp : 

$(MLSDK)/tools/mabu/data/components/OpenGL.comp : 

$(MLSDK)/.metadata/components/poco_netssl.comp : 

$(MLSDK)/.metadata/components/poco_crypto.comp : 

$(MLSDK)/tools/mabu/data/options/warn/on.option : 

$(MLSDK)/tools/mabu/data/options/debug/on.option : 

$(MLSDK)/.metadata/components/poco_xml.comp : 

$(MLSDK)/tools/mabu/data/configs/debug.config : 

$(MLSDK)/.metadata/components/poco_util.comp : 

$(MLSDK)/.metadata/components/poco_net.comp : 

$(MLSDK)/tools/mabu/data/options/standard-c++/17.option : 

$(MLSDK)/.metadata/components/poco_json.comp : 

$(MLSDK)/tools/mabu/data/options/package/debuggable/on.option : 

$(MLSDK)/.metadata/components/ml_sdk_common.comp : 

$(MLSDK)/tools/mabu/data/options/runtime/shared.option : 

PROGRAM_PREFIX=
PROGRAM_EXT=
SHARED_PREFIX=lib
SHARED_EXT=.so
IMPLIB_PREFIX=lib
IMPLIB_EXT=.so
STATIC_PREFIX=lib
STATIC_EXT=.a
COMPILER_PREFIX=
LINKER_PREFIX=

-make-directories : D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64 D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/Codec D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/Codec/SoftwareCodec D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/GraphicsDevice D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/GraphicsDevice/OpenGL

D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64 : 
	$(ECHO) @mkdir -p D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64

D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin : 
	$(ECHO) @mkdir -p D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin

D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/Codec : 
	$(ECHO) @mkdir -p D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/Codec

D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/Codec/SoftwareCodec : 
	$(ECHO) @mkdir -p D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/Codec/SoftwareCodec

D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/GraphicsDevice : 
	$(ECHO) @mkdir -p D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/GraphicsDevice

D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/GraphicsDevice/OpenGL : 
	$(ECHO) @mkdir -p D:/Dev/GitProjects/com.unity.webrtc/Plugin~/WebRTCPlugin/.out/debug_lumin_clang-3.8_aarch64/obj.WebRTCPlugin/GraphicsDevice/OpenGL

include $(WebRTCPlugin_OUTPUT)/WebRTCPlugin.mk
build :  | WebRTCPlugin-all

