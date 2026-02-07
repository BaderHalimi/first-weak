<template>
  <div
    class="layout bg-gray-800 text-white min-h-screen flex flex-col justify-between"
  >
    <nav class="flex items-center justify-between p-4 bg-black/10">
      <h1>My Application</h1>
      <ul class="flex space-x-4">
        <li><NuxtLink to="/" class="hover:text-gray-300">Home</NuxtLink></li>
        <li>
          <NuxtLink to="/about" class="hover:text-gray-300">About</NuxtLink>
        </li>
        <li><NuxtLink to="" class="hover:text-gray-300">Contact</NuxtLink></li>
      </ul>
      <div>
        <NuxtLink to="/dashboard"
          class="border border-gray-100 hover:bg-gray-100 hover:text-gray-600 text-white font-bold py-2 px-4 rounded"
        >
          Dashboard
        </NuxtLink>
      </div>
    </nav>
    <slot />
    <footer></footer>
  </div>
</template>
