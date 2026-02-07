<template>
  <div class="container">
    <h1 class="text-white">Welcome to the Homepage</h1>
    <p class="text-white">This is the main index page of your application.</p>
  </div>
</template>

<script>
export default {
  name: "IndexPage",
  head() {
    return {
      title: "Home - Your App",
    };
  },
};
useSeoMeta({
  title: "Home",
  description: "Multivendor platform!",
});
</script>

<style scoped>
.container {
  max-width: 1200px;
  margin: 0 auto;
  padding: 2rem;
  text-align: center;
}

h1 {
  font-size: 2.5rem;
  margin-bottom: 1rem;
}

p {
  font-size: 1.2rem;
}
</style>
