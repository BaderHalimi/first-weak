<template>
  <div class="error min-h-screen flex items-center justify-center bg-gray-100">
    <div
      class="bg-white rounded-lg items-center shadow-lg p-6 md:w-[50%] lg:w-[50%] w-full flex flex-col gap-4"
    >
      <h1 class="text-2xl bg-red-500 text-white p-2 rounded-lg">
        {{ error.statusCode }}
      </h1>
      <h1 class="text-5xl font-bold text-gray-800 mb-4">
        {{ error.statusCode == 404 ? "Not Found" : error.message }}
      </h1>
      <button
        @click="$router.push({ name: 'index' })"
        class="bg-blue-500 hover:bg-blue-600 text-white font-medium py-2 px-4 rounded transition duration-200"
      >
        Go To Home
      </button>
    </div>
  </div>
</template>
<script setup>
defineProps(["error"]);
</script>
